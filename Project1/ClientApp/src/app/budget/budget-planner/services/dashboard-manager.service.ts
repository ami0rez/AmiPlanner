import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { BudgetPage } from '../models/budget-page';
import { BudgetDashboardService } from './budget-dashboard.service';

@Injectable({
  providedIn: 'root'
})
export class DashboardManagerService {

  constructor(private dashboardService: BudgetDashboardService) { }

  async loadDashboard(pageObject: BudgetPage) {
    const result = await lastValueFrom(this.dashboardService.getDashboard(pageObject.data.budgetTrackingDate));
    pageObject.data.dashboard = result;
  }
}
