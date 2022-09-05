import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { Observable } from 'rxjs';
import { AuthenticationQuery } from '../models/authentication-query';
import { AuthenticationResponse } from '../models/authentication-response';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  readonly accountUrl =
    this.appConfigService.appConfig.apiUrl + 'api/v1/Account';

  constructor(
    private http: HttpClient,
    private appConfigService: AppConfigService
  ) {}

  public login(query: AuthenticationQuery): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(`${this.accountUrl}/Login`, query);
  }
}
