import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { BudgetSpentItem } from '../models/budget-spent-item';
import { BudgetSpentResponse } from '../models/budget-spent-response';

@Injectable({
  providedIn: 'root'
})
export class BudgetSpentService {

  private readonly budgetSpentingUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/BudgetSpent';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getItems(parentId: string) {
    return this.http.get<BudgetSpentResponse>(`${this.budgetSpentingUrl}/${parentId}`);
  }
  createItem(item: BudgetSpentItem) {
    return this.http.post<BudgetSpentResponse>(`${this.budgetSpentingUrl}`, item);
  }
  updateItem(item: BudgetSpentItem) {
    return this.http.put<BudgetSpentResponse>(`${this.budgetSpentingUrl}/${item.id}`, item);
  }
  deleteItem(itemId: string) {
    return this.http.delete<BudgetSpentResponse>(`${this.budgetSpentingUrl}/${itemId}`);
  }
}
