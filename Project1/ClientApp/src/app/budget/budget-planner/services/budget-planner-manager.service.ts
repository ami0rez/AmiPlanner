import { BudgetTrackItem } from './../models/budget-track-item';
import { BudgetPage } from './../models/budget-page';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { BudgetPlannerService } from './budget-planner.service';
import { BudgetTypes } from '../models/enums/budget-type';
import { toUtcDateFromString } from 'involys-common/common';

@Injectable({
  providedIn: 'root'
})
export class BudgetPlannerManagerService {
  constructor(private budgetPlanner: BudgetPlannerService) { }


  async getPlans(pageObject: BudgetPage) {
    const result = await lastValueFrom(this.budgetPlanner.getPlanns());
    this.updatePlansData(pageObject, result);
  }
  async saveBudgetPlan(pageObject: BudgetPage, item: BudgetTrackItem) {
    let result;
    if (item.id) {
      result = await lastValueFrom(this.budgetPlanner.updateBudgetPlan(item));
    } else {
      result = await lastValueFrom(this.budgetPlanner.createBudgetPlan(item));
    }
    this.updatePlansData(pageObject, result);
  }


  async initTypeOptions(pageObject: BudgetPage) {
    pageObject.typeOptions = Object.values(BudgetTypes)
      .filter(value => typeof value !== 'number')
      .map((item, index) => ({ label: item.toString(), value: index }));
  }

  async deleteBudgetPlan(pageObject: BudgetPage, item: BudgetTrackItem) {
    let result;
    if (item.id) {
      result = await lastValueFrom(this.budgetPlanner.deleteBudgetPlan(item.id));
    }
    this.updatePlansData(pageObject, result);
  }

  async updatePlansData(pageObject: BudgetPage, data: BudgetTrackItem[]) {
    data?.forEach(item => {
      item.categoryLabel = pageObject.categoryOptions.find(opt => opt.value === item.categoryId)?.label;
      item.date = toUtcDateFromString(item.date);
    });
    pageObject.data.budgetTracker.plans = data;
  }
}
