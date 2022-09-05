import { ProjectItemResponse } from './../models/project-item-response';
import { ProjectUpdateQuery } from './../models/project-update-query';
import { ListItem } from './../../common/models/list-item';
import { ProjectCreateQuery } from './../models/project-create-query';
import { lastValueFrom } from 'rxjs';
import { Injectable } from '@angular/core';
import { GoalServiceService } from 'src/app/goal/services/goal-service.service';
import { ProjectPage } from '../models/project-page';
import { ProjectEditorService } from './project-editor.service';
import { TaskManagerService } from './task-manager.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectManagerService {
  constructor(private readonly goalService: GoalServiceService, private readonly projectService: ProjectEditorService, private readonly taskManagerService: TaskManagerService) { }

  async loadGoal(pageObject: ProjectPage, id: string) {

    pageObject.loading = true;
    const result = await lastValueFrom(this.goalService.getGoalById(id));
    pageObject.data.currentGoal = result;
    const resultProjecrts = result.projects.map(project => ({ label: project.name, value: project.id }))
    pageObject.data.projectItems = [...resultProjecrts]
    pageObject.loading = false;
  }
  async loadProject(pageObject: ProjectPage, id: string) {
    if (!pageObject.data.openedProjects?.some(project => project.id === id)) {
      pageObject.loading = true;
      const result = await lastValueFrom(this.projectService.getProjectById(id));
      pageObject.data.openedProjects = [...(pageObject.data.openedProjects ?? []), result]
      pageObject.loading = false;
    }
    pageObject.selectedProjectId = id
    pageObject.data.selectedProject = pageObject.data.openedProjects.find(project => project.id === id);
    this.taskManagerService.filterAndSortTasksByPriority(pageObject);
  }

  async createProject(pageObject: ProjectPage, name: string) {
    pageObject.loading = true;
    const query: ProjectCreateQuery = {
      name: name,
      goalId: pageObject.data.currentGoal.id,
    }
    const result = await lastValueFrom(this.projectService.createProject(query));
    pageObject.data.projectItems = [...(pageObject.data.projectItems ?? []), { label: name, value: result?.id }]
    pageObject.loading = false;
  }

  // async createTask(pageObject: ProjectPage, name: string) {
  //   pageObject.loading = true;
  //   const query: GoalCreateQuery = {
  //     name: name,
  //     folderId: pageObject.data.currenfFolder.id,
  //   }
  //   const result = await lastValueFrom(this.goalService.createGoal(query));
  //   pageObject.data.folderItems = [...(pageObject.data.folderItems ?? []), { label: name, value: result?.id, folder: false}]
  //   pageObject.loading = false;
  // }

  async deleteProject(pageObject: ProjectPage, id: string) {
    pageObject.loading = true;
    await lastValueFrom(this.projectService.deleteProject(id));
    pageObject.data.projectItems = pageObject.data.projectItems?.filter(item => item.value != id)
    pageObject.loading = false;
  }

  async updateProject(pageObject: ProjectPage, project: ListItem) {
    pageObject.loading = true;
    const query: ProjectUpdateQuery = {
      goalId: pageObject.data.currentGoal.id,
      id: project.value,
      name: project.label
    }
    await lastValueFrom(this.projectService.updateProject(project.value, query));
    // pageObject.data.projectItems = pageObject.data.projectItems?.filter(item => item.value != id)
    pageObject.loading = false;
  }
  // async deleteTask(pageObject: ProjectPage, id: string) {
  //   pageObject.loading = true;
  //   await lastValueFrom(this.goalService.deleteGoal(id));
  //   pageObject.data.folderItems = pageObject.data.folderItems?.filter(item => (item.value != id && !item.folder) || item.folder)
  //   pageObject.loading = false;
  // }

  // addCurrentToPath(pageObject: ProjectPage) {
  //   const { currenfFolder } = pageObject.data;
  //   const current = { label: currenfFolder.name, value: currenfFolder.id, folder: true }
  //   pageObject.data.currentpath?.push(current)
  // }

  // // Remove from path until you reach id
  // removePathUntil(pageObject: ProjectPage, id: string) {
  //   let index = pageObject.data.currentpath?.length - 1;
  //   while (pageObject.data.currentpath?.length > 1) {
  //     if (pageObject.data.currentpath[index].value === id) {
  //       break;
  //     } else {
  //       pageObject.data.currentpath = pageObject.data.currentpath.filter(item => item.value != pageObject.data.currentpath[index].value)
  //     }
  //   }
  // }


  opnedProject(pageObject: ProjectPage, project: ProjectItemResponse) {
    pageObject.selectedProjectId = project?.id;
    pageObject.data.selectedProject = project;
    this.taskManagerService.filterAndSortTasksByPriority(pageObject);
  }

  closeOpnedProject(pageObject: ProjectPage, id: string) {
    pageObject.data.openedProjects = pageObject.data.openedProjects.filter(project => project.id != id);
    if (pageObject.data.openedProjects.length > 0) {
      var project = pageObject.data.openedProjects[0];
      pageObject.data.selectedProject = project;
      pageObject.selectedProjectId = project.id;
    } else {
      pageObject.data.selectedProject = undefined;
      pageObject.selectedProjectId = undefined;
    }
    pageObject.data.selectedTask = undefined;
    pageObject.data.filteredTasks = [];
    pageObject.showTaskContent = false;
  }
}
