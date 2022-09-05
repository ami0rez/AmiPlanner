import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfigService } from 'involys-common/common';
import { ChangerMotDePasseQuery } from '../models/changer-mot-de-passe-query';

@Injectable({
  providedIn: 'root',
})
export class ChangerMotDePasseService {
  readonly accountUrl =
  this.appConfigService.appConfig.apiUrl + 'api/v1/Account';

  constructor(private http: HttpClient, private appConfigService: AppConfigService) {}

  /**
   *  @description sends a request to change user's password 
   */
  updatePassword(changerMetDePasse: ChangerMotDePasseQuery): Observable<void> {
    return this.http.post<void>(this.accountUrl + '/ChangePassword', changerMetDePasse);
  }
}
