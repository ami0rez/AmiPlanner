import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TaskStateEnum } from 'src/app/project/models/task/task-state-enum';
import { DailyTasksPage } from '../../models/daily-tasks-page';

@Component({
  selector: 'app-daily-tasks-filter',
  templateUrl: './daily-tasks-filter.component.html',
  styleUrls: ['./daily-tasks-filter.component.css']
})
export class DailyTasksFilterComponent implements OnInit {

  @Input()
  pageObject: DailyTasksPage;
  @Output()
  pageObjectChanges: EventEmitter<DailyTasksPage> = new EventEmitter<DailyTasksPage>();
  @Output()
  filter: EventEmitter<any> = new EventEmitter<any>();

  taskStateSearchOptions = [
    { label: 'Todo', value: TaskStateEnum.Todo },
    { label: 'Doing', value: TaskStateEnum.Doing },
    { label: 'Done', value: TaskStateEnum.Done },
    { label: 'Hold', value: TaskStateEnum.Hold },
    { label: 'Abandoned', value: TaskStateEnum.Abandoned },
  ]

  constructor() { }

  async ngOnInit() {
  }

  /*
  * show Sub Task Filters
  */
  showSubTaskFilters(){
    this.pageObject.showTaskSubfilters = !this.pageObject.showTaskSubfilters;
  }

  /*
  * show Sub Task Filters
  */
  filterUpdated(){
    this.filter.emit();
  }

}
