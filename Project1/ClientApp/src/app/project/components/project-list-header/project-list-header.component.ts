import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-project-list-header',
  templateUrl: './project-list-header.component.html',
  styleUrls: ['./project-list-header.component.css']
})
export class ProjectListHeaderComponent implements OnInit {
  public readonly SearchMode = "SearchMode";
  public readonly CreateMode = "CreateMode";

  @Output() search: EventEmitter<string> = new EventEmitter<string>();
  @Output() filter: EventEmitter<any> = new EventEmitter<any>();
  @Output() addProject: EventEmitter<any> = new EventEmitter<any>();
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

  handleProjectAdd(event): void {
    const value = event.target.value;
    event.target.value = "";
    this.addProject.emit(value);
  }

}
