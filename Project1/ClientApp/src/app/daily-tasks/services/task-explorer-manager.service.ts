import { ListItemUtils } from './../../common/utils/list-item-utils';
import { TaskExplorerService } from './task-explorer.service';
import { Injectable } from '@angular/core';
import { DailyTasksPage } from '../models/daily-tasks-page';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskExplorerManagerService {
  constructor(protected taskService: TaskExplorerService) { }

  async getTaskExplorer(pageObject: DailyTasksPage){
    const result = await lastValueFrom(this.taskService.getOptions());
    ListItemUtils.addAllOption(result.folders);
    ListItemUtils.addAllOption(result.goals);
    ListItemUtils.addAllOption(result.projects);
    pageObject.taskFilterOptions = result;
  }
}
