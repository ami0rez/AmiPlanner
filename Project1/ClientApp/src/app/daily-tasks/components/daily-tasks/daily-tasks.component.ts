import { PageConstants } from 'src/app/common/constants/pages';
import { BreadCrumbService } from './../../../common/services/breadcrumb.service';
import { TaskUpdateQuery } from './../../../project/models/task/task-update-query';
import { TaskItemResponse } from './../../../project/models/task/task-item-response';
import { DailyTasksPage } from './../../models/daily-tasks-page';
import { Component, OnInit, SimpleChanges } from '@angular/core';
import { TaskManagerService } from 'src/app/project/services/task-manager.service';
import { Colors } from 'src/app/common/constants/colors';
import { TaskUtils } from 'src/app/common/utils/task-utils';
import { TaskExplorerManagerService } from '../../services/task-explorer-manager.service';

@Component({
  selector: 'app-daily-tasks',
  templateUrl: './daily-tasks.component.html',
  styleUrls: ['./daily-tasks.component.css']
})
export class DailyTasksComponent implements OnInit {

  pageObject = new DailyTasksPage();

  constructor(
    private readonly taskManagerService: TaskManagerService,
    private taskExplorerManagerService: TaskExplorerManagerService,
    private breadCrumbService: BreadCrumbService,
  ) { }

  async ngOnInit() {
    this.breadCrumbService.setBreadcumbItem({
      label: 'Daily Tasks',
      url: PageConstants.taskUrl
    })
    await this.taskExplorerManagerService.getTaskExplorer(this.pageObject);
    await this.taskManagerService.filterTasks(this.pageObject, {})
  }
  getClassName = TaskUtils.getClassName;

  showControls: boolean;
  appColors = Colors;
  taskStates = ["todo", "doing", "done", "abandoned", "hold", "todo"];
  unknownState = "unknown";
  className = "unknown";
  startTranstitionStates = [0, 3, 4, 5];
  donneTransitionStates = [1];
  abandonTransitionStates = [0, 1, 4, 5];
  holdTransitiontate = [1];
  startStateValue = 1;
  donneStateValue = 2;
  abandonStateValue = 3;
  holdStateValue = 4;
  waitingTotateValue = 5;

  ngOnChanges(changes: SimpleChanges): void {
  }

  openDescription(id) {
    this.pageObject.showTaskContent = true;
    this.taskManagerService.openDailyTask(this.pageObject, id)
  }

  //#region Tasks
  async handleFilter() {
    await this.taskManagerService.filterTasks(this.pageObject, this.pageObject.taskSearchFilter)
  }

  handleSort(event): void {
  }
  handleTaskStateUpdate(event): void {
    this.taskManagerService.updateTaskState(this.pageObject, event.id, event.state);
    setTimeout(() => {
      this.taskManagerService.calculateTodayStatistics(this.pageObject);
    }, 500);
  }
  handleDateTaskUpdate(event): void {
    this.taskManagerService.updateTaskDate(this.pageObject, event.id, event.date);
  }
  handleRepeatTaskUpdate(event): void {
    this.taskManagerService.updateTaskRepeat(this.pageObject, event.id, event.everyday);
  }
  handleOpenTask(task): void {
    this.taskManagerService.openTask(this.pageObject, task.id);
  }
  handleDelete(task): void {
  }
  handleTaskDescriptionClose(): void {
    this.taskManagerService.closeOpnedTask(this.pageObject);
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
  //#endregion

}
