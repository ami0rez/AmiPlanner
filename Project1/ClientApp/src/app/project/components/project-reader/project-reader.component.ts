import { TaskItemResponse } from './../../models/task/task-item-response';
import { TaskUpdateQuery } from './../../models/task/task-update-query';
import { TaskManagerService } from './../../services/task-manager.service';
import { ProjectPage } from './../../models/project-page';
import { Component, Input, OnInit } from '@angular/core';
import { Colors } from 'src/app/common/constants/colors';
import { ProjectManagerService } from '../../services/project-manager.service';

@Component({
  selector: 'app-project-reader',
  templateUrl: './project-reader.component.html',
  styleUrls: ['./project-reader.component.css']
})
export class ProjectReaderComponent implements OnInit {

  @Input() pageObject: ProjectPage;
  filteredList = [];
  selectedIndex = 0;
  showTaskContent = false;
  appColors = Colors;
  constructor(private projectManagerService: ProjectManagerService, private taskManagerService: TaskManagerService) { }

  ngOnInit(): void {
  }

  handleClick(project): void {
    this.projectManagerService.closeOpnedProject(this.pageObject, project);
  }

  handleOnClose(project): void {
    this.projectManagerService.closeOpnedProject(this.pageObject, project.id);
  }

  //#region Tasks
  handleSearchChange(event): void {

  }
  //#region Tasks
  handleTaskFilter(): void {
    this.taskManagerService.filterAndSortTasksByPriority(this.pageObject);
  }
  handleFilter(event): void {
  }
  handleAddTask(event): void {
    this.taskManagerService.createTask(this.pageObject, event);
  }
  handleSort(event): void {
  }
  handleTaskStateUpdate(event): void {
    this.taskManagerService.updateTaskState(this.pageObject, event.id, event.state);
  }
  handleDateTaskUpdate(event): void {
    this.taskManagerService.updateTaskDate(this.pageObject, event.id, event.date);
  }
  handleRepeatTaskUpdate(event): void {
    this.taskManagerService.updateTaskRepeat(this.pageObject, event.id, event.everyday);
  }
  async handlePriorityTaskUpdate(event) {
    await this.taskManagerService.updateTaskPriority(this.pageObject, event.id, event.priority);
  }
  handleTaskUpdate(task: TaskItemResponse): void {
    if (task.id) {
      const query: TaskUpdateQuery = {
        completed: task.completed,
        date: task.date,
        description: task.description,
        estimated: task.estimated,
        everyday: task.everyday,
        id: task.id,
        name: task.name,
        projectId: task.projectId,
        rest: task.rest,
        state: task.state,
        priority: task.priority
      }
      this.taskManagerService.updateTaskDescription(this.pageObject, task.id, query);
    }
  }
  handleOpenTask(task): void {
    if (task.everyday || task.date) {
      this.taskManagerService.openDailyTask(this.pageObject, task.id);
    } else {
      this.taskManagerService.openTask(this.pageObject, task.id);
    }
  }
  handleDelete(task): void {
    this.taskManagerService.deleteTask(this.pageObject, task.id);
  }
  handleTaskDescriptionClose(): void {
    this.taskManagerService.closeOpnedTask(this.pageObject);
  }
  //#endregion
}
