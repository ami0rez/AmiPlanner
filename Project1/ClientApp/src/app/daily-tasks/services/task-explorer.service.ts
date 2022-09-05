import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { TaskFilterOptions } from '../models/task-filter-options';

@Injectable({
  providedIn: 'root'
})
export class TaskExplorerService {

  private readonly taskExplorerUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/TaskExplorer';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getOptions() {
    return this.http.get<TaskFilterOptions>(`${this.taskExplorerUrl}/Options`);
  }
}
