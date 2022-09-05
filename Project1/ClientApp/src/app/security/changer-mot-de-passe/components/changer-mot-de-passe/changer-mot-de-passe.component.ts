import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { ChangerMotDePasseQuery } from '../../models/changer-mot-de-passe-query';
import { CommonNotificationService } from 'involys-common/common';
import { ChangerMotDePasseService } from '../../services/changer-mot-de-passe.service';
import { BreadcrumbService } from 'involys-library';
import { AuthenticationService } from 'src/common/services/authentication.service';
import { UrlConstants } from 'src/common/services/models/url-constants';

@Component({
  selector: 'app-changer-mot-de-passe',
  templateUrl: './changer-mot-de-passe.component.html',
})
export class ChangerMotDePasseComponent implements OnInit {
  password: ChangerMotDePasseQuery = new ChangerMotDePasseQuery();
  passwordConfirmation: string;

  constructor(
    private notificationService: CommonNotificationService,
    private changePasswordsService: ChangerMotDePasseService,
    private authenticationService: AuthenticationService,
    private route: Router,
    private location: Location,
    private breadcrumbService: BreadcrumbService
  ) {}

  async ngOnInit() {
    this.initBreadCrumb();
    this.password.login = this.authenticationService.userProfile.login;
    if (!this.password.login) {
      const emailNotProvided = $localize`:@@changer-mot-de-passe.emailNotProvird: Email not provided`;
      this.notificationService.showError(emailNotProvided);
    }
  }

  /**
   * add path to breadcrumb
   */
  private initBreadCrumb() {
    this.breadcrumbService.initialize();
    this.breadcrumbService.add({
      label: $localize`:@@changer-mot-de-passe.breadcrumb:Password modification`,
      routerLink: [UrlConstants.updatePasswordUrl],
    });
  }

  /**
   * @description check uf the password is valid
   */
  async validatePassword() {
    const invalidFields = [];
    if (!this.password.oldPassword) {
      invalidFields.push(
        $localize`:@@changer-mot-de-passe.oldPassword:Old password`
      );
    }
    if (!this.password.newPassword) {
      invalidFields.push(
        $localize`:@@changer-mot-de-passe.newPassword:New password`
      );
    }
    if (!this.passwordConfirmation) {
      invalidFields.push(
        $localize`:@@changer-mot-de-passe.passwordConfirmation:Password confirmation`
      );
    }
    if (invalidFields.length > 0) {
      this.notificationService.showError(
        $localize`:@@global.fillSpeceficRequiredFields: Please enter all required fields: ` +
          invalidFields.join(', ')
      );
      return false;
    }

    if (this.password.newPassword?.length < 8) {
      this.notificationService.showError(
        $localize`:@@changer-mot-de-passe.passwordLengthInvalid8Chars:Invalid password, password must contain 8 characters`
      );
      return false;
    }

    if (this.password.newPassword !== this.passwordConfirmation) {
      this.notificationService.showError(
        $localize`:@@changer-mot-de-passe.passwordAreNotIdentical:Password are not identical`
      );
      return false;
    }
    return true;
  }

  /**
   * @description change's current user's password
   */
  async changePassword() {
    const valid = await this.validatePassword();
    if (!valid) {
      return;
    }
    await this.changePasswordsService.updatePassword(this.password).toPromise();
    this.notificationService.showUpdateSuccess();
    this.redirectToHomePage();
  }

  /**
   * @description cancel changing user's password
   */
  async cancelChangingPassword() {
    try {
      this.location.back();
    } catch {
      this.route.navigate([UrlConstants.home]);
    }
  }

  /**
   *  @description redirect user to home page
   */
  redirectToHomePage() {
    this.route.navigate([UrlConstants.home]);
  }
}
