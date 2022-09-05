import { ListItem } from './../../../common/models/list-item';
import { TaskSearchFilter } from './../../models/task/task-search-filter';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TaskStateEnum } from '../../models/task/task-state-enum';
import { TaskConstants } from '../../models/task/task-constants';

@Component({
  selector: 'app-project-task-header',
  templateUrl: './project-task-header.component.html',
  styleUrls: ['./project-task-header.component.css']
})
export class ProjectTaskHeaderComponent implements OnInit {

  public readonly SearchMode = "SearchMode";
  public readonly CreateMode = "CreateMode";

  @Output() next: EventEmitter<string> = new EventEmitter<string>();
  @Output() search: EventEmitter<string> = new EventEmitter<string>();
  @Output() filter: EventEmitter<any> = new EventEmitter<any>();
  @Output() addTask: EventEmitter<any> = new EventEmitter<any>();
  @Output() sort: EventEmitter<any> = new EventEmitter<any>();

  @Input() mode: string = this.SearchMode;
  @Input() sortAscending: boolean;
  @Input() taskStateSearchOptions: ListItem[] = [];
  @Input() taskSortOptions: ListItem[] = [];

  @Input() taskSearchFilter: TaskSearchFilter;
  @Output() taskSearchFilterChange: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
    this.taskStateSearchOptions = [
      { label: 'All', value: undefined },
      { label: 'Todo', value: TaskStateEnum.Todo },
      { label: 'Today', value: TaskStateEnum.WaitingToStart },
      { label: 'Doing', value: TaskStateEnum.Doing },
      { label: 'Done', value: TaskStateEnum.Done },
      { label: 'Hold', value: TaskStateEnum.Hold },
      { label: 'Abandoned', value: TaskStateEnum.Abandoned },
    ]
    this.taskSortOptions = [
      { label: 'Priority Desc', value: TaskConstants.PriorityDesc },
      { label: 'Priority Asc', value: TaskConstants.PriorityAsc },
      { label: 'Name Desc', value: TaskConstants.NameDesc },
      { label: 'Name Asc', value: TaskConstants.NameAsc },
      { label: 'State Desc', value: TaskConstants.StateDesc },
      { label: 'State Asc', value: TaskConstants.StateAsc },
    ]
    this.taskSearchFilter.sortBy = this.taskSortOptions[0];
  }

  setMode(newMode): void {
    this.mode = newMode;
  }

  handleSort(ascending): void {
    this.sortAscending = ascending
    this.sort.emit(ascending);
  }

  handleSearchChange(): void {
    this.next.emit();
  }

  handleSelectChange(event): void {
    //ToBeImplemented
  }

  handleTaskAdd(event): void {
    const value = event.target.value;
    event.target.value = "";
    this.addTask.emit(value);
  }

}
