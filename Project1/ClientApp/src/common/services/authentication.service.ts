import { UrlConstants } from './models/url-constants';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserProfile } from './models/user-profile';
import { AuthenticationSettings } from './models/authentication-settings';
import { AuthenticationResponse } from 'src/app/security/login/models/authentication-response';
import { RefreshTokenResponse } from 'src/app/security/common/models/refresh-token-response';


@Injectable({
  providedIn: 'root',
})
/**
 *  @description Manage logged user and authentication
 */
export class AuthenticationService {
  private readonly profileKey = 'profile';
  private readonly authenticationSettingsKey = 'auth-settings';
  private user = null;
  private authSettings = null;
  private authChangeSub = new Subject<UserProfile>();
  public authChanged = this.authChangeSub.asObservable();
  private jwtHelper: JwtHelperService;

  constructor(private router: Router) {
    this.jwtHelper = new JwtHelperService();
  }

  /**
   *  @description Check if user authenticated
   */
  public get userAuthenticated() {
    return localStorage.getItem(this.profileKey) !== null;
  }

  /**
   *  @description Get authentication settings
   */
  public get authenticationSettings(): AuthenticationSettings {
    if (this.authSettings) {
      return this.authSettings;
    }
    const jsonSettings = localStorage.getItem(this.authenticationSettingsKey);
    this.authSettings = JSON.parse(jsonSettings);
    return this.authSettings;
  }

  /**
   *  @description Get Access Token
   */
  public static getAccessToken(): string {
    const jsonSettings = localStorage.getItem('auth-settings');
    const authSettings = JSON.parse(jsonSettings);
    const token = authSettings?.accessToken;
    return token;
  }

  /**
   *  @description get user profile
   */
  public get userProfile(): UserProfile {
    if (this.user) {
      return this.user;
    }
    const jsonProfile = localStorage.getItem(this.profileKey);
    this.user = JSON.parse(jsonProfile);
    return this.user;
  }

  /**
   *  @description Send a notification about user authentication status
   */
  public sendAuthenticatedNotification(user: UserProfile) {
    this.authChangeSub.next(user);
  }

  /**
   *  @description Get Access Token
   */
  public accessTokenValid(): boolean {
    const token = this.authenticationSettings?.accessToken;
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  /**
   *  @description save settings after user connected
   */
  completeAuthentication(response: AuthenticationResponse) {
    localStorage.setItem(this.profileKey, JSON.stringify(response.profile));

    const authentication: AuthenticationSettings = {
      accessToken: response.accessToken,
      accessTokenType: response.accessTokenType,
      refreshToken: response.refreshToken,
    };
    localStorage.setItem(
      this.authenticationSettingsKey,
      JSON.stringify(authentication)
    );
    this.sendAuthenticatedNotification(response.profile);
  }
  /**
   *  @description save new access token and refresh token after token is refreshed
   */
  completeSilentRenew(response: RefreshTokenResponse) {
    const authentication: AuthenticationSettings = {
      ...this.authenticationSettings,
      accessToken: response.accessToken,
      refreshToken: response.refreshToken,
    };
    localStorage.setItem(
      this.authenticationSettingsKey,
      JSON.stringify(authentication)
    );
  }

  /**
   *  @description start authenticating
   */
  startAuthentication() {
    localStorage.removeItem(this.profileKey);
    localStorage.removeItem(this.authenticationSettingsKey);
    this.user = null;
    this.authSettings = null;
    this.sendAuthenticatedNotification(null);
    this.router.navigate([UrlConstants.loginUrl]);
  }

  /**
   *  @description logout
   */
  public logout() {
    localStorage.removeItem(this.profileKey);
    localStorage.removeItem(this.authenticationSettingsKey);
    this.user = null;
    this.authSettings = null;
    this.sendAuthenticatedNotification(null);
    this.router.navigate([UrlConstants.logoutUrl]);
  }

  /**
   *  @description  get authorization header (token)
   */
  getAuthorizationHeaderValue(): string {
    if (
      this.userProfile === null ||
      this.userProfile === undefined ||
      this.authenticationSettings?.accessToken === null ||
      this.authenticationSettings?.accessToken === undefined
    ) {
      return '';
    } else {
      return `${this.authenticationSettings.accessTokenType} ${this.authenticationSettings.accessToken}`;
    }
  }
}
