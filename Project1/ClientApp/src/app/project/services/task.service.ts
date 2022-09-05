import { DailyTaskItemResponse } from './../../daily-tasks/models/daily-task-item-response';
import { TaskUpdateQuery } from './../models/task/task-update-query';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { TaskCreateQuery } from '../models/task/task-create-query';
import { TaskItemResponse } from '../models/task/task-item-response';
import { TaskFilterQuery } from 'src/app/daily-tasks/models/task-filter-query';
import { TaskFilterListItemResponse } from 'src/app/daily-tasks/models/task-filter-list-item-response';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private readonly TaskUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/Task';

  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  filter(query: TaskFilterQuery): Observable<TaskFilterListItemResponse[]> {
    return this.http.post<TaskFilterListItemResponse[]>(`${this.TaskUrl}/Filter`, query);
  }
  getTaskById(id): Observable<TaskItemResponse> {
    return this.http.get<TaskItemResponse>(`${this.TaskUrl}/${id}`);
  }
  getDailyTaskById(id): Observable<DailyTaskItemResponse> {
    return this.http.get<DailyTaskItemResponse>(`${this.TaskUrl}/daily/${id}`);
  }
  updateTaskState(id: string, state): Observable<void> {
    return this.http.get<void>(`${this.TaskUrl}/State/${id}/${state}`);
  }
  updateTaskDate(id: string, date: string): Observable<void> {
    const dateQuery = date ? `?date=${date}`: '';
    return this.http.get<void>(`${this.TaskUrl}/Date/${id}${dateQuery}`);
  }
  updateTask(id: string, task: TaskUpdateQuery): Observable<void> {
    return this.http.put<void>(`${this.TaskUrl}/${id}`, task);
  }
  updateTaskDescription(id: string, task: TaskUpdateQuery): Observable<void> {
    return this.http.put<void>(`${this.TaskUrl}/Description/${id}`, task);
  }
  updateTaskRepeat(id: string, repeat): Observable<void> {
    return this.http.get<void>(`${this.TaskUrl}/Repeat/${id}/${repeat}`);
  }
  updateTaskPriority(id: string, repeat): Observable<void> {
    return this.http.get<void>(`${this.TaskUrl}/Priority/${id}/${repeat}`);
  }
  createTask(query: TaskCreateQuery): Observable<TaskItemResponse> {
    return this.http.post<TaskItemResponse>(`${this.TaskUrl}`, query);
  }
  // deleteTask(id): Observable<void> {
  //   return this.http.delete<void>(`${this.TaskUrl}/${id}`);
  // }
}
