import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { AppConfigService } from 'src/app/common/services/app-config-service';
import { FolderCreateQuery } from '../models/folder/folder-create-query';
import { FolderItemResponse } from '../models/folder/folder-item-response';
import { GoalCreateQuery } from '../models/goal-create-query';
import { GoalItemResponse } from '../models/goal-item-response';
import { GoalListItemResponse } from '../models/goal-list-item-response';
import { GoalUpdateQuery } from '../models/goal-update-query';

@Injectable({
  providedIn: 'root',
})
export class GoalServiceService {
  private readonly goalUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/Goal';
  private readonly folderUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/folder';

  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getAll(): Observable<GoalListItemResponse[]> {
    return this.http.get<GoalListItemResponse[]>(this.goalUrl);
  }
  getGoalById(id): Observable<GoalItemResponse> {
    return this.http.get<GoalItemResponse>(`${this.goalUrl}/${id}`);
  }
  getFolderById(id): Observable<FolderItemResponse> {
    const param = id ? `?id=${id}` : ''
    return this.http.get<FolderItemResponse>(`${this.folderUrl}/Id${param}`);
  }
  updateGoal(id: string, query: GoalUpdateQuery): Observable<void> {
    return this.http.put<void>(`${this.goalUrl}/${id}`, query);
  }
  createGoal(query: GoalCreateQuery): Observable<GoalItemResponse> {
    return this.http.post<GoalItemResponse>(`${this.goalUrl}`, query);
  }
  createFolder(query: FolderCreateQuery): Observable<FolderItemResponse> {
    return this.http.post<FolderItemResponse>(`${this.folderUrl}`, query);
  }
  deleteGoal(id): Observable<void> {
    return this.http.delete<void>(`${this.goalUrl}/${id}`);
  }
  deleteFolder(id): Observable<void> {
    return this.http.delete<void>(`${this.folderUrl}/${id}`);
  }
}
