import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';
import { BudgetSpentItem } from '../models/budget-spent-item';

@Injectable({
  providedIn: 'root'
})
export class BudgetSpentService {

  private readonly budgetSpentingUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/BudgetSpent';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  getItems(parentId: string) {
    return this.http.get<BudgetSpentItem[]>(`${this.budgetSpentingUrl}/${parentId}`);
  }
  createItem(item: BudgetSpentItem) {
    return this.http.post<BudgetSpentItem>(`${this.budgetSpentingUrl}`, item);
  }
  updateItem(item: BudgetSpentItem) {
    return this.http.put<BudgetSpentItem[]>(`${this.budgetSpentingUrl}/${item.id}`, item);
  }
  deleteItem(itemId: string) {
    return this.http.delete<BudgetSpentItem[]>(`${this.budgetSpentingUrl}/${itemId}`);
  }
}
