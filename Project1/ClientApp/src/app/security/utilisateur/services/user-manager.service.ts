import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { BreadcrumbService, DynamicFieldType } from 'involys-library';
import { CommonConstants, Toolbox } from 'involys-common/common';
import { ConfirmationDialogService } from 'involys-common/common';
import { CommonNotificationService } from 'involys-common/common';
import { UtilisateurService } from './utilisateur.service';
import { UtilisateurPage } from '../models/utilisateur-page';
import { UtilisateurResponse } from '../models/utilisateur-response';
import { UpdateUtilisateurQuery } from '../models/update-utilisateur-query';
import { CreateUtilisateurQuery } from '../models/create-utilisateur-query';
import { Constants } from 'src/app/common/global-constants';
import { UtilisateurListItemResponse } from '../models/utilisateur-list-item-response';
import { BreadCrumbRoutesConstants } from 'src/app/common/breadcrumb-routes-constants';

@Injectable({
  providedIn: 'root',
})
export class UserManagerService {
  emailPattern = CommonConstants.emailPattern;
  usernamePattern = Constants.usernamePattern;

  constructor(
    private readonly confirmationService: ConfirmationDialogService,
    private readonly notificationService: CommonNotificationService,
    private readonly utilisateurService: UtilisateurService,
    private route: Router,
    private readonly breadcrumbService: BreadcrumbService
  ) {}

  /**
   * init split button actions
   */
  initActions(pageObject: UtilisateurPage) {
    this.manageActionsVisibility(pageObject);
    pageObject.splitButtonActions = [
      {
        label: $localize`:@@global.supprimer: Supprimer`,
        icon: 'pi inv-delete_red-i',
        command: () => this.deleteEditingUser(pageObject),
      },
    ];
  }
  /**
   * manage Actions visibility
   */
  manageActionsVisibility(pageObject: UtilisateurPage) {
    if (pageObject.data.utilisateur) {
      pageObject.showActions = !this.isUserDefaultAdmin(
        pageObject.data.utilisateur
      );
    } else {
      pageObject.showActions = false;
    }
  }

  /**
   *  @description get all users
   */
  public async getAllUsers(pageObject: UtilisateurPage) {
    const users = await this.utilisateurService.getAll().toPromise();
    pageObject.data.listeUtilisateurs = users.map((user) => ({
      ...user,
      hideDelete: this.isUserDefaultAdmin(user),
    }));
    pageObject.data.listeUtilisateursFiltre = pageObject.data.listeUtilisateurs;
  }
  /**
   *  @description  Gets user by its id
   */
  public async getUserById(pageObject: UtilisateurPage, id: string) {
    const user = await this.utilisateurService.getUserById(id).toPromise();
    pageObject.data.utilisateur = user;
    this.generateFakePassword(pageObject);
    this.disableAdminInputs(pageObject);
    pageObject.initialData.utilisateur = this.cloneUser(
      pageObject.data.utilisateur
    );
  }

  /**
   *  @description generates fake password and adds it to user's data
   */
  public async generateFakePassword(pageObject: UtilisateurPage) {
    pageObject.data.utilisateur = {
      ...pageObject.data.utilisateur,
      motDePasse: CommonConstants.fakePassword,
      confirmationMotDePasse: CommonConstants.fakePassword,
    };
  }

  /**
   *  @description checks if user is default admin and disables login and admin inputs
   */
  public async disableAdminInputs(pageObject: UtilisateurPage) {
    if (this.isUserDefaultAdmin(pageObject.data.utilisateur)) {
      pageObject.login.enabled = false;
      pageObject.admin.enabled = false;
      pageObject.bloque.enabled = false;
    } else {
      pageObject.login.enabled = true;
      pageObject.admin.enabled = true;
      pageObject.bloque.enabled = true;
    }
  }

  /**
   *  @description checks if user is default admin
   *  @param user user to check
   */
  protected isUserDefaultAdmin(
    user: UtilisateurResponse | UtilisateurListItemResponse
  ): boolean {
    return user.login === Constants.defaultAdminLogin;
  }

  /**
   *  @description Clone User
   * @param user user to clone
   */
  public cloneUser(user: UtilisateurResponse) {
    return {
      ...user,
    };
  }

  /**
   *  @description returns the username
   *  @param pageObject user page data
   */
  getUserName(pageObject: UtilisateurPage): string {
    let username = '';
    if (pageObject.data.utilisateur.prenom || pageObject.data.utilisateur.nom) {
      username =
        (pageObject.data.utilisateur.prenom ?? '') +
        ' ' +
        (pageObject.data.utilisateur.nom ?? '');
    } else {
      username = pageObject.data.utilisateur.login;
    }
    return username;
  }

  /**
   *  @description Reinitialize User
   *  @param pageObject user page data
   */
  public reinitializeUser(pageObject: UtilisateurPage) {
    pageObject.data.utilisateur = this.cloneUser(
      pageObject.initialData.utilisateur
    );
  }

  /**
   *  @description Save the passed user (Create / Update)
   *  @param pageObject user page data
   *  @param userId user Id
   */
  public async saveUser(pageObject: UtilisateurPage, userId) {
    if (!this.validateFields(pageObject)) {
      return false;
    }
    if (userId) {
      await this.updateUser(pageObject);
    } else {
      const createdUser = await this.createUser(pageObject);
      userId = createdUser.id;
      pageObject.data.utilisateur.id = createdUser.id;
    }
    pageObject.editMode = false;
    return userId;
  }

  /**
   *  @description Update user
   *  @param pageObject user page data
   */
  public async updateUser(pageObject: UtilisateurPage) {
    const { utilisateur } = pageObject.data;
    const updateQuery: UpdateUtilisateurQuery = {
      bloque: utilisateur.bloque,
      admin: utilisateur.admin,
      email: utilisateur.email,
      login: utilisateur.login,
      motDePasse:
        utilisateur.motDePasse != CommonConstants.fakePassword
          ? utilisateur.motDePasse
          : null,
      nom: utilisateur.nom,
      prenom: utilisateur.prenom,
    };
    await this.utilisateurService
      .updateUser(utilisateur.id, updateQuery)
      .toPromise();
    this.notificationService.showUpdateSuccess();
  }

  /**
   *  @description create a user
   *  @param pageObject user page data
   */
  public async createUser(pageObject: UtilisateurPage) {
    const { utilisateur } = pageObject.data;
    const createQuery: CreateUtilisateurQuery = {
      bloque: utilisateur.bloque,
      admin: utilisateur.admin,
      email: utilisateur.email,
      login: utilisateur.login,
      motDePasse: utilisateur.motDePasse,
      nom: utilisateur.nom,
      prenom: utilisateur.prenom,
    };
    const responseUser = await this.utilisateurService
      .createUser(createQuery)
      .toPromise();
    this.notificationService.showCreateSuccess();
    this.removeNewFromBreadCrumb();
    return responseUser;
  }

  /**
   *  @description removes the added new from breadcrumb
   */
  public async removeNewFromBreadCrumb() {
    this.breadcrumbService.removePrevious();
  }

  /**
   *  @description delete user
   */
  public async deleteUser(pageObject: UtilisateurPage, userId: string) {
    this.confirmationService.confirm({
      message: $localize`:@@global.deleteConfirmation:Do you want to delete this record ?`,
      accept: async () => {
        await this.utilisateurService.deleteUser(userId).toPromise();
        pageObject.data.listeUtilisateurs =
          pageObject.data.listeUtilisateurs.filter((u) => u.id != userId);
        pageObject.data.listeUtilisateursFiltre =
          pageObject.data.listeUtilisateursFiltre.filter((u) => u.id != userId);
        this.notificationService.showDeleteSuccess();
      },
    });
  }

  /**
   *  @description delete user
   */
  public async deleteEditingUser(pageObject: UtilisateurPage) {
    this.confirmationService.confirm({
      message: $localize`:@@global.deleteConfirmation:Do you want to delete this record ?`,
      accept: async () => {
        const { id } = pageObject.data.utilisateur;
        await this.utilisateurService.deleteUser(id).toPromise();
        this.route.navigate([BreadCrumbRoutesConstants.utilisateurListe]);
        this.notificationService.showDeleteSuccess();
      },
    });
  }

  /**
   *  @description validate user query data
   *  @param pageObject user page data
   */
  private validateFields(pageObject: UtilisateurPage): boolean {
    const { utilisateur } = pageObject.data;
    const invalidFields = [];
    if (!utilisateur.prenom) {
      invalidFields.push($localize`:@@user.firstName:First Name`);
    }
    if (!utilisateur.nom) {
      invalidFields.push($localize`:@@user.lastName: Last name`);
    }
    if (!utilisateur.login) {
      invalidFields.push($localize`:@@user.login: Login`);
    }
    if (!utilisateur.email) {
      invalidFields.push($localize`:@@user.email:E-mail`);
    }
    if (!utilisateur.motDePasse) {
      invalidFields.push($localize`:@@user.password: Password`);
    }
    if (!utilisateur.confirmationMotDePasse) {
      invalidFields.push(
        $localize`:@@user.passwordConfirmation: Password Confirmation`
      );
    }
    if (invalidFields.length > 0) {
      this.notificationService.showError(
        $localize`:@@global.fillSpeceficRequiredFields: Please enter all required fields: ` +
          invalidFields.join(', ')
      );
      return false;
    }

    if (!this.validateUserName(utilisateur.login)) {
      return false;
    }
    if (!this.emailPattern.test(utilisateur.email)) {
      this.notificationService.showError(
        $localize`:@@user.invalidEmailAddress:Invalid email address`
      );
      return false;
    }
    if (utilisateur.motDePasse && utilisateur.motDePasse.length < 8) {
      this.notificationService.showError(
        $localize`:@@user.passwordLengthInvalid8Chars: Le mot de passe doit contenir au moins 8 caractères`
      );
      return false;
    }
    if (utilisateur.motDePasse !== utilisateur.confirmationMotDePasse) {
      this.notificationService.showError(
        $localize`:@@user.passwordAreNotIdentical: Les mots de passe ne sont pas identiques`
      );
      return false;
    }
    return true;
  }

  /**
   *  @description verifies if user name construction is valid
   *  @param username user name (login)
   */
  validateUserName(username: string) {
    if (!this.usernamePattern.test(username)) {
      this.notificationService.showError(
        $localize`:@@user.invalidUserName: Invalid userName`
      );
      return false;
    }
    return true;
  }

  /**
   * Set filter and export columns.
   * @param pageObject global page object
   */
  initializeColumnsForFilterAndExport(pageObject: UtilisateurPage) {
    pageObject.columns = [
      {
        field: 'nom',
        header: $localize`:@@user.nom: Nom`,
        type: DynamicFieldType.InputText,
        options: [],
      },
      {
        field: 'prenom',
        header: $localize`:@@user.prenom: Prenom`,
        type: DynamicFieldType.InputText,
        options: [],
      },
      {
        field: 'login',
        header: $localize`:@@user.login: Login`,
        type: DynamicFieldType.InputText,
        options: [],
      },
      {
        field: 'email',
        header: $localize`:@@user.email: E-mail`,
        type: DynamicFieldType.InputText,
        options: [],
      },
      {
        field: 'admin',
        header: $localize`:@@user.administrator: Administrateur`,
        type: DynamicFieldType.CheckBox,
        options: [],
      },
      {
        field: 'bloque',
        header: $localize`:@@user.blocked: Bloque`,
        type: DynamicFieldType.CheckBox,
        options: [],
      },
    ];
    Toolbox.sortColumnTableFilter(pageObject.columns);
  }
}
