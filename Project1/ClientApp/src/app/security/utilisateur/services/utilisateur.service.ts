import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AppConfigService } from 'involys-common/common';
import { CreateUtilisateurQuery } from '../models/create-utilisateur-query';
import { UtilisateurResponse } from '../models/utilisateur-response';
import { UtilisateurListItemResponse } from '../models/utilisateur-list-item-response';
import { UpdateUtilisateurQuery } from '../models/update-utilisateur-query';
@Injectable({
  providedIn: 'root',
})
export class UtilisateurService {
  private readonly userUrl =
    this.appConfigService.appConfig.apiUrl + 'api/v1/Utilisateur';

  constructor(
    private http: HttpClient,
    private appConfigService: AppConfigService
  ) {}

  /**
   *  @description get all users from api
   */
  getAll(): Observable<UtilisateurListItemResponse[]> {
    return this.http.get<UtilisateurListItemResponse[]>(this.userUrl);
  }

  /**
   *  @description get a users by its id
   */
  getUserById(id): Observable<UtilisateurResponse> {
    return this.http.get<UtilisateurResponse>(`${this.userUrl}/${id}`);
  }

  /**
   *  @description update user
   */
  updateUser(id: string, query: UpdateUtilisateurQuery): Observable<void> {
    return this.http.put<void>(`${this.userUrl}/${id}`, query);
  }

  /**
   *  @description create a user
   */
  createUser(query: CreateUtilisateurQuery): Observable<UtilisateurResponse> {
    return this.http.post<UtilisateurResponse>(`${this.userUrl}`, query);
  }

  /**
   *  @description delete user
   */
  deleteUser(id): Observable<UtilisateurResponse> {
    return this.http.delete<UtilisateurResponse>(`${this.userUrl}/${id}`);
  }
}
