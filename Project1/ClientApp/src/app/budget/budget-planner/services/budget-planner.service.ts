import { BudgetTrackItem } from './../models/budget-track-item';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { BudgetTrackerResponse } from '../models/budget-tracker-response';

@Injectable({
  providedIn: 'root'
})
export class BudgetPlannerService {

  private readonly budgetTrackingUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/BudgetPlan';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getPlanns() {
    return this.http.get<BudgetTrackItem[]>(`${this.budgetTrackingUrl}`);
  }
  createBudgetPlan(item: BudgetTrackItem) {
    return this.http.post<BudgetTrackerResponse>(`${this.budgetTrackingUrl}`, item);
  }
  updateBudgetPlan(item: BudgetTrackItem) {
    return this.http.put<BudgetTrackerResponse>(`${this.budgetTrackingUrl}/${item.id}`, item);
  }
  deleteBudgetPlan(itemId: string) {
    return this.http.delete<BudgetTrackerResponse>(`${this.budgetTrackingUrl}/${itemId}`);
  }
}
