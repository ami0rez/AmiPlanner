import { toUtcDate } from 'involys-common/common';
import { BudgetTrackItem } from './../../models/budget-track-item';
import { BudgetTrackManagerService } from './../../services/budget-tracker-manager.service';
import { Component, Input, OnInit } from '@angular/core';
import { BudgetPage } from '../../models/budget-page';
import { BudgetTypes } from '../../models/enums/budget-type';
import { periodManagerService } from '../../services/period-manager.service';
import { BudgetSpentItem } from '../../models/budget-spent-item';
import { BudgetSpentManagerService } from '../../services/budget-spent-manager.service';

@Component({
  selector: 'app-budget-tracker',
  templateUrl: './budget-tracker.component.html',
  styleUrls: ['./budget-tracker.component.css']
})
export class BudgetTrackerComponent implements OnInit {

  @Input()
  pageObject: BudgetPage;
  constructor(private readonly budgetTrackManagerService: BudgetTrackManagerService,
    private readonly periodManagerService: periodManagerService,
    private readonly budgetSpentManagerService: BudgetSpentManagerService
    ) { }

  async ngOnInit() {}

  async saveIncom(item: BudgetTrackItem) {
    item.type = BudgetTypes.Incom;
    this.verifyDate(item);
    await this.budgetTrackManagerService.saveBudgetItem(this.pageObject, item);
  }
  async loadSpent(item: BudgetTrackItem) {
    await this.budgetSpentManagerService.getItems(item);
  }

  async saveSpent(budgetItem:BudgetTrackItem, item: BudgetSpentItem) {
    await this.budgetSpentManagerService.saveItem(budgetItem, item);
  }

  async deleteSpent(budgetItem:BudgetTrackItem, item: BudgetSpentItem) {
    await this.budgetSpentManagerService.deleteItem(budgetItem, item);
  }

  async saveSpentNeed(item) {
    item.type = BudgetTypes.Need;
    this.verifyDate(item);
    await this.budgetTrackManagerService.saveBudgetItem(this.pageObject, item);
  }

  async saveSpentWant(item) {
    item.type = BudgetTypes.Want;
    this.verifyDate(item);
    await this.budgetTrackManagerService.saveBudgetItem(this.pageObject, item);
  }

  async saveSavings(item) {
    item.type = BudgetTypes.Saving;
    this.verifyDate(item);
    await this.budgetTrackManagerService.saveBudgetItem(this.pageObject, item);
  }

  async deleteBudgetItem(item) {
    item.type = BudgetTypes.Saving;
    this.verifyDate(item);
    await this.budgetTrackManagerService.deleteBudgetItem(this.pageObject, item);
  }

  async budgetTrackingDateChange() {
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

  async import(event, fileUpload) {
    await this.budgetTrackManagerService.import(event, fileUpload);
  }


  /*
  *  @description verify if item has date, if not add date
  */
  verifyDate(item: BudgetTrackItem) {
    if (!item.id) {
      item.date = toUtcDate(this.pageObject.data.budgetTrackingDate) ?? new Date();
    }
  }

  async payBudgetItem(item) {
    await this.budgetTrackManagerService.payBudgetItem(this.pageObject, item);
  }

  async refundBudgetItem(item) {
    await this.budgetTrackManagerService.refundBudgetItem(this.pageObject, item);
  }

  async initPeriod() {
    await this.periodManagerService.initPeriod(toUtcDate(this.pageObject.data.budgetTrackingDate));
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

  async clearPeriod() {
    await this.periodManagerService.clearPeriod(toUtcDate(this.pageObject.data.budgetTrackingDate));
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

  async closePeriod() {
    await this.periodManagerService.closePeriod(toUtcDate(this.pageObject.data.budgetTrackingDate));
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

  async openPeriod() {
    await this.periodManagerService.openPeriod(toUtcDate(this.pageObject.data.budgetTrackingDate));
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

}
