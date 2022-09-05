import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { BreadcrumbService } from 'involys-library';
import { CommonConstants } from 'involys-common/common';
import { UtilisateurPage } from '../../models/utilisateur-page';
import { SecurityActionConstants } from 'involys-common/security';
import { UtilisateurResponse } from '../../models/utilisateur-response';
import { UserManagerService } from '../../services/user-manager.service';
import { BreadCrumbRoutesConstants } from 'src/app/common/constants/breadcrumb-routes-constants';

@Component({
  selector: 'app-utilisateur-edition',
  templateUrl: './utilisateur-edition.component.html',
  styleUrls: ['./utilisateur-edition.component.scss'],
})
export class UtilisateurEditionComponent implements OnInit {
  pageObject = new UtilisateurPage();

  rowsNumber = CommonConstants.rowsNumber;
  rowsPerPage = CommonConstants.rowsPerPage;
  userId: string;
  emailPattern = CommonConstants.emailPattern;
  userCreateUrl = BreadCrumbRoutesConstants.utilisateurCreation;
  userEditUrl = BreadCrumbRoutesConstants.utilisateurEdition;

  idParam = 'id';

  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private readonly userManagerService: UserManagerService,
    private readonly breadcrumbService: BreadcrumbService
  ) {}

  async ngOnInit() {
    this.activatedRoute.params.subscribe(async (params) => {
      this.userId = params[this.idParam];
      if (this.userId) {
        await this.userManagerService.getUserById(this.pageObject, this.userId);
        this.userManagerService.initActions(this.pageObject);
      }
      this.initEditMode();
      this.initBreadCrumb();
    });
  }

  /**
   *  @description Initializes the breadcrumb
   */
  initBreadCrumb() {
    if (this.userId) {
      const username = this.userManagerService.getUserName(this.pageObject);
      this.breadcrumbService.add({
        label: username,
        routerLink: [this.userEditUrl + this.userId],
      });
    } else {
      this.breadcrumbService.add({
        label: $localize`:@@global.new: New`,
        routerLink: [this.userCreateUrl],
      });
    }
    this.initEditMode();
  }

  /**
   *  @description Initialize edit mode
   */
  initEditMode() {
    if (
      this.activatedRoute.snapshot.routeConfig.path ===
        BreadCrumbRoutesConstants.utilisateurEditionPath ||
      this.activatedRoute.snapshot.routeConfig.path ===
        BreadCrumbRoutesConstants.utilisateurCreationPath
    ) {
      this.setEditMode(true);
    } else {
      this.setEditMode(false);
    }
  }

  /**
   *  @description Save user data (Create / Update)
   */
  async saveUser() {
    this.userId = await this.userManagerService.saveUser(
      this.pageObject,
      this.userId
    );
  }

  /**
   *  @description Enables editing mode
   */
  async enableEditMode() {
    this.setEditMode(true);
  }

  /**
   *  @description go to create user mode
   */
  createUser() {
    this.pageObject.createFromPage = true;
    this.pageObject.pageMode = SecurityActionConstants.Create;
    this.pageObject.data.utilisateur = new UtilisateurResponse();
    this.setEditMode(true);
    this.userId = undefined;
    this.refreshBreadCrumb($localize`:@@global.new: New`, this.userCreateUrl);
  }

  /**
   *  @description undo the user create and return to the previous mode
   */
  undoCreateUser() {
    this.pageObject.createFromPage = false;
    this.setEditMode(false);
    this.userId = this.pageObject.data.utilisateur?.id;
    const username = this.userManagerService.getUserName(this.pageObject);
    this.refreshBreadCrumb(username, this.userEditUrl + this.userId);
  }

  /**
   *  @description refresh breadcrumb
   */
  refreshBreadCrumb(name, link) {
    this.breadcrumbService.removePrevious();
    this.breadcrumbService.add({
      label: name,
      routerLink: [link],
    });
  }

  /**
   *  @description cancels editing
   */
  cancelEditing() {
    if (this.pageObject.editMode && this.userId) {
      this.setEditMode(false);
    } else if (this.pageObject.createFromPage) {
      this.undoCreateUser();
    } else {
      this.route.navigate([BreadCrumbRoutesConstants.utilisateurListe]);
    }
  }

  /**
   *  @description Sets Edit mode
   *  @param mode new edit mode
   */
  setEditMode(mode) {
    this.pageObject.editMode = mode;
    if (!this.pageObject.editMode) {
      this.userManagerService.reinitializeUser(this.pageObject);
    }
  }
}
