import { Component, Input, Output, EventEmitter, SimpleChanges, OnChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Colors } from 'src/app/common/constants/colors';
import { PageConstants } from 'src/app/common/constants/pages';
import { TaskStateEnum } from 'src/app/project/models/task/task-state-enum';
import { TaskFilterListItemResponse } from '../../models/task-filter-list-item-response';

@Component({
  selector: 'app-daily-tasks-item',
  templateUrl: './daily-tasks-item.component.html',
  styleUrls: ['./daily-tasks-item.component.css']
})
export class DailyTasksItemComponent implements OnChanges {

  @Input() task: TaskFilterListItemResponse;

  @Output() itemClick: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemDelete: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemStateUpdate: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemRepeatUpdate: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemPriorityUpdate: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemDateUpdate: EventEmitter<any> = new EventEmitter<any>();

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

  constructor(private router: Router) { }


  ngOnChanges(changes: SimpleChanges): void {
    this.className = this.getClassName();
  }

  handleTaskItemClick(): void {
    this.itemClick.emit();
  }

  handleOnDelete(event): void {
    this.itemDelete.emit(event);
    event.stopPropagation();
  }

  handleOnClick(event): void {
    this.itemClick.emit(event);
    event.stopPropagation();
  }

  stopPtopagation(event): void {
    event.stopPropagation();
  }
  handleOnUpdate(event, state: TaskStateEnum): void {
    this.itemStateUpdate.emit({ id: this.task.id, state: state });
    this.task.state = state;
    event.stopPropagation();
  }
  handleOnDateUpdate(event): void {
    const date = this.task.date ? undefined : new Date();
    this.itemDateUpdate.emit({ id: this.task.id, date: date });
    setTimeout(() => {
      this.task.date = date;
    }, 200);
    event.stopPropagation();
  }
  handleUpdateRepeat(event, everyday: boolean): void {
    this.itemRepeatUpdate.emit({ id: this.task.id, everyday: everyday });
    setTimeout(() => {
      this.task.everyday = everyday;
    }, 200);
    event.stopPropagation();
  }
  handleGoToProject(event, task){
    this.router.navigate([PageConstants.projectUrl, task.goalId])
    event.stopPropagation();
  }
  handleUpdatePriority(event): void {
    this.itemPriorityUpdate.emit({ id: this.task.id, priority: this.task.priority });
    event.stopPropagation();
  }

  getClassName(): string {
    if (this.task.state != null && this.task.state >= 0 && this.task.state < this.taskStates.length) {
      return this.taskStates[this.task.state]
    } else {
      return this.unknownState;
    }
  }
}
