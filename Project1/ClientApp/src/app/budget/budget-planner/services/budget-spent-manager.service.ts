import { BudgetTrackItem } from './../models/budget-track-item';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { BudgetSpentService } from './budget-spent.service';
import { BudgetSpentItem } from '../models/budget-spent-item';

@Injectable({
  providedIn: 'root'
})
export class BudgetSpentManagerService {
  constructor(private budgetSpent: BudgetSpentService) { }

  /*
  *  @description get items for spent items
  */
  async getItems(item: BudgetTrackItem) {
    const result = await lastValueFrom(this.budgetSpent.getItems(item.id));
    item.spent = result.spendings;
  }

  /*
  *  @description save items for spent items
  */
  async saveItem(trackItem: BudgetTrackItem, spentItem: BudgetSpentItem) {
    let result;
    if (spentItem.id) {
      result = await lastValueFrom(this.budgetSpent.updateItem(spentItem));
    } else {
      result = await lastValueFrom(this.budgetSpent.createItem(spentItem));
    }
    trackItem.spent = result.spendings;
  }

  /*
  *  @description delete items for spent items
  */
  async deleteItem(trackItem: BudgetTrackItem, spentItem: BudgetSpentItem) {
    let result;
    if (spentItem.id) {
      result = await lastValueFrom(this.budgetSpent.deleteItem(spentItem.id));
      trackItem.spent = result.spendings;
    }
  }
}
