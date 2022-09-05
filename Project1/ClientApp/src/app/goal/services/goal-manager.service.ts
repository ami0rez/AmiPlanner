import { GoalCreateQuery } from './../models/goal-create-query';
import { GoalPage } from './../models/goal-page';
import { Injectable } from '@angular/core';
import { GoalServiceService } from './goal-service.service';
import { lastValueFrom } from 'rxjs';
import { FolderCreateQuery } from '../models/folder/folder-create-query';

@Injectable({
  providedIn: 'root'
})
export class GoalManagerService {

  constructor(private readonly goalService: GoalServiceService) { }

  async loadFolder(pageObject: GoalPage, id: string) {
    pageObject.loading = true;
    const result = await lastValueFrom(this.goalService.getFolderById(id));
    pageObject.data.currenfFolder = result;
    const resultFolders = result.folders.map(folder => ({ label: folder.name, value: folder.id, folder: true }))
    const resultGoals = result.goals.map(goal => ({ label: goal.name, value: goal.id }))
    pageObject.data.folderItems = [...resultFolders, ...resultGoals]
    pageObject.loading = false;
  }

  async createFolder(pageObject: GoalPage, name: string) {
    pageObject.loading = true;
    const query: FolderCreateQuery = {
      name: name,
      folderId: pageObject.data.currenfFolder.id,
    }
    const result = await lastValueFrom(this.goalService.createFolder(query));
    pageObject.data.folderItems = [...(pageObject.data.folderItems ?? []), { label: name, value: result?.id, folder: true }]
    pageObject.loading = false;
  }

  async createGoal(pageObject: GoalPage, name: string) {
    pageObject.loading = true;
    const query: GoalCreateQuery = {
      name: name,
      folderId: pageObject.data.currenfFolder.id,
    }
    const result = await lastValueFrom(this.goalService.createGoal(query));
    pageObject.data.folderItems = [...(pageObject.data.folderItems ?? []), { label: name, value: result?.id, folder: false}]
    pageObject.loading = false;
  }

  async deleteFolder(pageObject: GoalPage, id: string) {
    pageObject.loading = true;
    await lastValueFrom(this.goalService.deleteFolder(id));
    pageObject.data.folderItems = pageObject.data.folderItems?.filter(item => (item.value != id && item.folder)|| !item.folder)
    pageObject.loading = false;
  }
  async deleteGoal(pageObject: GoalPage, id: string) {
    pageObject.loading = true;
    await lastValueFrom(this.goalService.deleteGoal(id));
    pageObject.data.folderItems = pageObject.data.folderItems?.filter(item => (item.value != id && !item.folder) || item.folder)
    pageObject.loading = false;
  }

  addCurrentToPath(pageObject: GoalPage) {
    const { currenfFolder } = pageObject.data;
    const current = { label: currenfFolder.name, value: currenfFolder.id, folder: true }
    pageObject.data.currentpath?.push(current)
  }

  // Remove from path until you reach id
  removePathUntil(pageObject: GoalPage, id: string) {
    let index = pageObject.data.currentpath?.length - 1;
    while (pageObject.data.currentpath?.length > 1) {
      if (pageObject.data.currentpath[index].value === id) {
        break;
      } else {
        pageObject.data.currentpath = pageObject.data.currentpath.filter(item => item.value != pageObject.data.currentpath[index].value)
      }
    }
  }
}
