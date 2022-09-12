import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationQuery } from '../models/authentication-query';
import { AuthenticationResponse } from '../models/authentication-response';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  readonly accountUrl ='http://localhost:5000/api/v1/Account';

  constructor(
    private http: HttpClient
  ) {}

  public login(query: AuthenticationQuery): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(`${this.accountUrl}/Login`, query);
  }
}
