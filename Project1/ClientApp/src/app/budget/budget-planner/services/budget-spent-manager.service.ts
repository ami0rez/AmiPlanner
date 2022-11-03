import { BudgetTrackItem } from './../models/budget-track-item';
import { BudgetPage } from './../models/budget-page';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { BudgetTrackService } from './budget-tracker.service';
import { BudgetTrackerResponse } from '../models/budget-tracker-response';
import { toUtcDate } from 'involys-common/common';

@Injectable({
  providedIn: 'root'
})
export class BudgetSpentManagerService {
  constructor(private budgetTrack: BudgetTrackService) { }

  async loadOptions(pageObject: BudgetPage) {
    const result = await lastValueFrom(this.budgetTrack.getOptions());
    pageObject.categoryOptions = result;
    pageObject.categoryOptions.unshift({ label: "Select", value: null })
  }
  async getTrackingItems(pageObject: BudgetPage) {
    const result = await lastValueFrom(this.budgetTrack.getTrackingItems(toUtcDate(pageObject.data.budgetTrackingDate)));
    this.updateData(pageObject, result);
  }
  async getPlanningItems(pageObject: BudgetPage) {
    const result = await lastValueFrom(this.budgetTrack.getPlanningItems());
    this.updatePlansData(pageObject, result);
  }
  async saveBudgetItem(pageObject: BudgetPage, item: BudgetTrackItem) {
    let result;
    if (item.id) {
      result = await lastValueFrom(this.budgetTrack.updateBudgetItem(item));
    } else {
      result = await lastValueFrom(this.budgetTrack.createBudgetItem(item));
    }
    this.updateData(pageObject, result);
  }

  async payBudgetItem(pageObject: BudgetPage, item: BudgetTrackItem) {
    const result = await lastValueFrom(this.budgetTrack.payBudgetItem(item.id));
    this.updateData(pageObject, result);
  }

  async refundBudgetItem(pageObject: BudgetPage, item: BudgetTrackItem) {
    const result = await lastValueFrom(this.budgetTrack.refundBudgetItem(item.id));
    this.updateData(pageObject, result);
  }

  async deleteBudgetItem(pageObject: BudgetPage, item: BudgetTrackItem) {
    let result;
    if (item.id) {
      result = await lastValueFrom(this.budgetTrack.deleteBudgetItem(item.id));
    }
    this.updateData(pageObject, result);
  }

  async updateData(pageObject: BudgetPage, data: BudgetTrackerResponse) {
    data.spentWants?.forEach(item => item.categoryLabel = pageObject.categoryOptions.find(opt => opt.value === item.categoryId)?.label);
    data.spentNeeds?.forEach(item => item.categoryLabel = pageObject.categoryOptions.find(opt => opt.value === item.categoryId)?.label);
    pageObject.data.budgetTracker = { ...pageObject.data.budgetTracker, ...data };
  }


  async updatePlansData(pageObject: BudgetPage, data: BudgetTrackItem[]) {
    data?.forEach(item => item.categoryLabel = pageObject.categoryOptions.find(opt => opt.value === item.categoryId)?.label);
    pageObject.data.budgetTracker.plans = data;
  }
  
  async import(event, fileUpload) {
    const formData = new FormData();
    formData.append('file', event.currentFiles[0], event.currentFiles[0].name);
    const result = await lastValueFrom(this.budgetTrack.import(formData));
    if (result) {
      //this.notificationService.showSuccess('Done uploading');
    } else {
      //this.notificationService.showError('Error Uploading');
    }
    fileUpload.clear();
  }
}
