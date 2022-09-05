import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
// import { CommonNotificationService } from 'involys-common/common';
import { AuthenticationService } from 'src/common/services/authentication.service';
import { AuthenticationQuery } from '../../models/authentication-query';
import { AuthenticationResponse } from '../../models/authentication-response';
import { LoginPage } from '../../models/login-page';
import { LoginService } from '../../services/login.service';

@Injectable({
  providedIn: 'root',
})
/**
 *  @description Manage login page actions
 */
export class LoginManagerService {
  constructor(
    private loginService: LoginService,
    // private notificationService: CommonNotificationService,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {}

  /**
   *  @description Login user
   */
  async login(pageObject: LoginPage) {
    var query: AuthenticationQuery = {
      password: pageObject.data.password,
      userName: pageObject.data.userName,
      rememberLogin: pageObject.data.rememberLogin,
    };
    if (!this.validateLogin(query)) {
      return;
    }
    var result = await this.loginService.login(query).toPromise();
    this.manageLoginSuccess(pageObject, result);
  }

  /**
   *  @description complete authentication if user logged in
   */
  manageLoginSuccess(pageObject: LoginPage, response: AuthenticationResponse) {
    this.authenticationService.completeAuthentication(response);
    this.router.navigate([pageObject.data.returnUrl]);
  }

  /**
   *  @description validates user info before trying to login
   */
  validateLogin(query: AuthenticationQuery) {
    if (!query.userName) {
      // this.notificationService.showError(
      //   $localize`:@@login.userNameError: UserName is required`
      // );
      return false;
    }
    if (!query.password) {
      // this.notificationService.showError(
      //   $localize`:@@login.passWordError: Password is required`
      // );
      return false;
    }

    return true;
  }
}
