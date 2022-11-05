import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { BudgetDashboardResponse } from '../models/budget-dashboard';

@Injectable({
  providedIn: 'root'
})
export class BudgetDashboardService {

  private readonly dashboardUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/Dashboard';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getDashboard(date: Date) {
    return this.http.get<BudgetDashboardResponse>(`${this.dashboardUrl}/Budget?date=${date.toISOString()}`);
  }
}
