import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-goal-header',
  templateUrl: './goal-header.component.html',
  styleUrls: ['./goal-header.component.css']
})
export class GoalHeaderComponent implements OnInit {

  public readonly SearchMode = "SearchMode";
  public readonly CreateFolderMode = "CreateFolderMode";
  public readonly CreateGoalMode = "CreateGoalMode";

  @Output() search: EventEmitter<string> = new EventEmitter<string>();
  @Output() filter: EventEmitter<any> = new EventEmitter<any>();
  @Output() addGoal: EventEmitter<any> = new EventEmitter<any>();
  @Output() addFolder: EventEmitter<any> = new EventEmitter<any>();
  @Output() sort: EventEmitter<any> = new EventEmitter<any>();

  @Input() mode : string = this.SearchMode;
  @Input() sortAscending : boolean;
  @Input() taskSearchOptions = [];


  constructor() { }

  ngOnInit(): void {
  }

  setMode(newMode): void {
    this.mode = newMode;
  }

  handleSort(ascending): void {
    this.sortAscending = ascending
    this.sort.emit(ascending);
  }

  handleSearchChange(event): void {
    this.search.emit(event.target.value);
  }

  handleSelectChange(event): void {
    //ToBeImplemented
  }

  handleCreateFile(event): void {
    this.addGoal.emit(event.target.value);
  }

  handleCreateFolder(event): void {
    this.addFolder.emit(event.target.value);
  }
}
