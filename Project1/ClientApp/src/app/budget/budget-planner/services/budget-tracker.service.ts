import { BudgetTrackItem } from './../models/budget-track-item';
import { ListItem } from './../../../common/models/list-item';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { BudgetTrackerResponse } from '../models/budget-tracker-response';

@Injectable({
  providedIn: 'root'
})
export class BudgetTrackService {

  private readonly budgetTrackingUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/BudgetTrack';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getOptions() {
    return this.http.get<ListItem[]>(`${this.budgetTrackingUrl}/Options`);
  }

  getTrackingItems(date: Date) {
    return this.http.get<BudgetTrackerResponse>(`${this.budgetTrackingUrl}?date=${date.toISOString()}`);
  }

  getPlanningItems() {
    return this.http.get<BudgetTrackItem[]>(`${this.budgetTrackingUrl}/Plans`);
  }
  createBudgetItem(item: BudgetTrackItem) {
    return this.http.post<BudgetTrackerResponse>(`${this.budgetTrackingUrl}`, item);
  }
  updateBudgetItem(item: BudgetTrackItem) {
    return this.http.put<BudgetTrackerResponse>(`${this.budgetTrackingUrl}/${item.id}`, item);
  }
  deleteBudgetItem(itemId: string) {
    return this.http.delete<BudgetTrackerResponse>(`${this.budgetTrackingUrl}/${itemId}`);
  }
}
