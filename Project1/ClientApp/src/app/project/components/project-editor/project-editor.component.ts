import { BreadCrumbService } from './../../../common/services/breadcrumb.service';
import { ProjectManagerService } from './../../services/project-manager.service';
import { ProjectPage } from './../../models/project-page';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskManagerService } from '../../services/task-manager.service';

@Component({
  selector: 'app-project-editor',
  templateUrl: './project-editor.component.html',
  styleUrls: ['./project-editor.component.css']
})
export class ProjectEditorComponent implements OnInit {

  pageObject = new ProjectPage();
  constructor(
    private projectManagerService: ProjectManagerService,
    private taskManagerService: TaskManagerService,
    private breadCrumbService: BreadCrumbService,
    private route: ActivatedRoute) { }

  async ngOnInit() {
    this.breadCrumbService.addBreadcumbItem({
      label: 'Project',
    })
    const goalId = this.route.snapshot.paramMap.get('gaolId');
    const projetctId = this.route.snapshot.paramMap.get('projectId');
    const taskId = this.route.snapshot.paramMap.get('id');
    await this.projectManagerService.loadGoal(this.pageObject, goalId)
    if (projetctId) {
      await this.projectManagerService.loadProject(this.pageObject, projetctId)
    }
    if(taskId){
      this.taskManagerService.openTask(this.pageObject, taskId);
    }
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
