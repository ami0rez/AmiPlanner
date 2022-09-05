import { ProjectManagerService } from './../../services/project-manager.service';
import { ProjectPage } from './../../models/project-page';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-project-editor',
  templateUrl: './project-editor.component.html',
  styleUrls: ['./project-editor.component.css']
})
export class ProjectEditorComponent implements OnInit {

  pageObject = new ProjectPage();
  constructor(private projectManagerService: ProjectManagerService, private route: ActivatedRoute) { }

  async ngOnInit() {
    const goalId = this.route.snapshot.paramMap.get('id');
    await this.projectManagerService.loadGoal(this.pageObject, goalId)
  }

  async openProject(projectItem) {
    await this.projectManagerService.loadProject(this.pageObject, projectItem.value)
  }

  async addProject(projectName) {
    await this.projectManagerService.createProject(this.pageObject, projectName)
  }

  async deleteProject(projectItem) {
    await this.projectManagerService.deleteProject(this.pageObject, projectItem.value)
  }

  async renameProject(projectItem) {
    await this.projectManagerService.updateProject(this.pageObject, projectItem)
  }
}
