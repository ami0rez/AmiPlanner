import { ListItem } from './../../../common/models/list-item';
import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { ProjectPage } from '../../models/project-page';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnChanges {

  @Input() pageObject: ProjectPage;

  @Output() pageObjectChange: EventEmitter<ProjectPage> = new EventEmitter<ProjectPage>();
  @Output() openProject: EventEmitter<any> = new EventEmitter<any>();
  @Output() addProject: EventEmitter<any> = new EventEmitter<any>();
  @Output() deleteProject: EventEmitter<any> = new EventEmitter<any>();
  @Output() renameProject: EventEmitter<any> = new EventEmitter<any>();

  displayedItems: ListItem[];


  constructor() { }

  ngOnChanges(): void {
  }

  handleOpenProject(item): void {
    this.openProject.emit(item);
  }

  handleDeleteProject(item): void {
    this.deleteProject.emit(item);
  }
  handleRenameProject(item, newName): void {
    item.label = newName;
    this.renameProject.emit(item);
  }
  handleAddProject(project) {
    this.addProject.emit(project);
  }
  handleSearchProject(project: string) {
    this.displayedItems = this.pageObject.data.projectItems?.filter(item => item.label?.includes(project) || project.includes(item.label))
  }
}
