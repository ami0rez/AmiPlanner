import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import {
  CustomFilter,
  CustomPredefinedFilter,
  FilterEnum,
  FilterUtils,
  MenuItem,
} from 'involys-library';
import { BreadcrumbService } from 'involys-library';
import { CommonConstants } from 'involys-common/common';
import { UtilisateurPage } from '../../models/utilisateur-page';
import { BreadCrumbRoutesConstants } from 'src/app/common/breadcrumb-routes-constants';
import { UserManagerService } from '../../services/user-manager.service';
import { UtilisateurListItemResponse } from '../../models/utilisateur-list-item-response';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-utilisateur-liste',
  templateUrl: './utilisateur-liste.component.html',
  styleUrls: ['./utilisateur-liste.component.scss'],
})
export class UtilisateurComponent implements OnInit {
  // popup attributes
  @Input() isFromPopup = false;

  datePattern = CommonConstants.localDatePattern;
  pageObject = new UtilisateurPage();
  rowsNumber = CommonConstants.rowsNumber;
  rowsPerPage = CommonConstants.rowsPerPage;
  pageIndex: number;

  splitButtonItems: MenuItem[];

  tableUserIndex = 0;
  userListUrl = BreadCrumbRoutesConstants.utilisateurListe;
  constructor(
    private route: Router,
    private readonly userManagerService: UserManagerService,
    private datePipe: DatePipe,
    private readonly breadcrumbService: BreadcrumbService
  ) {}

  async ngOnInit() {
    this.initBreadCrumb();
    this.userManagerService.initializeColumnsForFilterAndExport(
      this.pageObject
    );
    await this.userManagerService.getAllUsers(this.pageObject);
  }

  /**
   *  @description initialize breadcrumb
   */
  async initBreadCrumb() {
    const breadCrumb = this.breadcrumbService.getBreadcrumb();
    const lastElement = breadCrumb[breadCrumb.length - 1].routerLink;
    if (lastElement && lastElement.length) {
      if (
        lastElement[0].includes(BreadCrumbRoutesConstants.utilisateurEdition)
      ) {
        this.breadcrumbService.removePrevious();
      } else {
        this.breadcrumbService.add({
          label: $localize`:@@user.pageName: Users`,
          routerLink: [this.userListUrl],
        });
      }
    } else {
      this.breadcrumbService.initialize();
      this.breadcrumbService.add({
        label: $localize`:@@user.pageName: Users`,
        routerLink: [this.userListUrl],
      });
    }
  }
  
  /**
   *  @description delete user
   */
  async deleteUser(user: UtilisateurListItemResponse) {
    await this.userManagerService.deleteUser(this.pageObject, user.id);
  }

  /**
   *  @description select user
   */
  public selectUser(user: UtilisateurListItemResponse) {
    this.route.navigate([
      BreadCrumbRoutesConstants.utilisateurEdition,
      user.id,
    ]);
  }

  /**
   *  @description Edit user
   */
  public editUser(user: UtilisateurListItemResponse) {
    this.route.navigate([
      BreadCrumbRoutesConstants.utilisateurEdition,
      user.id,
      CommonConstants.editMode,
    ]);
  }

  /**
   *  @description create user
   */
  public createUser() {
    this.route.navigate([BreadCrumbRoutesConstants.utilisateurCreation]);
  }

  //#region Filtres

  /**
   *  @description remove condition
   */
  removeCondition(conditions) {
    this.pageObject.conditions = conditions;
  }

  /**
   *  @description apply predefined filters
   * @param listeUtilisateursFiltre // the table values
   */
  displayFilter(listeUtilisateursFiltre) {
    if (listeUtilisateursFiltre) {
      this.pageObject.data.listeUtilisateursFiltre = listeUtilisateursFiltre;
    }
  }

  /**
   * add Predefined Conditions
   */
  applyFilter(predefinedFilter: CustomPredefinedFilter[]) {
    predefinedFilter.forEach((filter) => {
      if (filter.active && !this.pageObject.conditions.includes(filter.label)) {
        this.pageObject.conditions.push(filter.label);
      }
    });
  }

  /**
   *  @description clear filter
   */
  clearFilter() {
    this.pageObject.data.listeUtilisateursFiltre =
      this.pageObject.data.listeUtilisateurs;
    this.pageObject.conditions = [];
    this.pageObject.selectedFilters = [];
  }

  /**
   *  @description addFilterConditions
   */
  addConditionFilter(selectedFilters: CustomFilter[]) {
    this.pageObject.conditions = [];
    this.applyFilter(this.pageObject.predefinedFilter);
    this.addFilterConditions(selectedFilters, this.pageObject);
  }

  /**
   *  @description addFilterConditions
   */
  addFilterConditions(
    selectedFilters: CustomFilter[],
    pageObject: UtilisateurPage
  ) {
    pageObject.selectedFilters = selectedFilters;
    selectedFilters.forEach((element) => {
      let conditions = element.column.header;
      element.filter.forEach((f) => {
        if (f.filterType === FilterEnum.ChildOf) {
          conditions +=
            CommonConstants.space +
            FilterUtils.getOptionByFilterEnum(FilterEnum.ChildOf) +
            CommonConstants.space +
            f.value;
        } else if (f.value instanceof Date) {
          const dateString: string = this.datePipe.transform(
            f.value,
            this.datePattern
          );
          conditions +=
            CommonConstants.space +
            FilterUtils.getOptionByFilterEnum(f.filterName) +
            CommonConstants.space +
            dateString;
        } else {
          conditions +=
            CommonConstants.space +
            FilterUtils.getOptionByFilterEnum(f.filterName) +
            CommonConstants.space +
            f.value;
        }
        pageObject.conditions.push(conditions);
      });
    });
  }
  //#endregion
}
