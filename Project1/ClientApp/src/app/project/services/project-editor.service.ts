import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { ProjectCreateQuery } from '../models/project-create-query';
import { ProjectItemResponse } from '../models/project-item-response';
import { ProjectListItemResponse } from '../models/project-list-item-response';
import { ProjectUpdateQuery } from '../models/project-update-query';

@Injectable({
  providedIn: 'root'
})
export class ProjectEditorService {

  private readonly projectUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/Project';

  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getAll(): Observable<ProjectListItemResponse[]> {
    return this.http.get<ProjectListItemResponse[]>(this.projectUrl);
  }
  getProjectById(id): Observable<ProjectItemResponse> {
    return this.http.get<ProjectItemResponse>(`${this.projectUrl}/${id}`);
  }
  updateProject(id: string, query: ProjectUpdateQuery): Observable<void> {
    return this.http.put<void>(`${this.projectUrl}/${id}`, query);
  }
  createProject(query: ProjectCreateQuery): Observable<ProjectItemResponse> {
    return this.http.post<ProjectItemResponse>(`${this.projectUrl}`, query);
  }
  deleteProject(id): Observable<void> {
    return this.http.delete<void>(`${this.projectUrl}/${id}`);
  }
}
