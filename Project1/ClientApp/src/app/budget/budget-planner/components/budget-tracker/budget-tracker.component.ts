import { BudgetTrackItem } from './../../models/budget-track-item';
import { BudgetTrackManagerService } from './../../services/budget-tracker-manager.service';
import { Component, OnInit } from '@angular/core';
import { BudgetPage } from '../../models/budget-page';
import { BudgetTypes } from '../../models/enums/budget-type';

@Component({
  selector: 'app-budget-tracker',
  templateUrl: './budget-tracker.component.html',
  styleUrls: ['./budget-tracker.component.css']
})
export class BudgetTrackerComponent implements OnInit {

  pageObject: BudgetPage = new BudgetPage();
  constructor(private readonly budgetTrackManagerService: BudgetTrackManagerService) { }

  async ngOnInit() {
    await this.budgetTrackManagerService.loadOptions(this.pageObject);
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

  async saveIncom(item: BudgetTrackItem) {
    item.type = BudgetTypes.Incom;
    this.verifyDate(item);
    await this.budgetTrackManagerService.saveBudgetItem(this.pageObject, item);
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

  /*
  *  @description verify if item has date, if not add date
  */
  verifyDate(item: BudgetTrackItem) {
    if (!item.id) {
      item.date = this.pageObject.data.budgetTrackingDate ?? new Date();
    }
  }

}
