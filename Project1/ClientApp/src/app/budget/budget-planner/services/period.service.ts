import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from 'src/app/common/services/app-config-service';

@Injectable({
  providedIn: 'root'
})
export class PeriodService {

  private readonly budgetTrackingUrl = this.appConfigService.appConfig.apiUrl + 'api/v1/Amip/Period';
  constructor(private http: HttpClient, private appConfigService: AppConfigService) { }

  initPeriod(date: Date) {
    return this.http.get<void>(`${this.budgetTrackingUrl}/Init?date=${date.toISOString()}`);
  }
  clearPeriod(date: Date) {
    return this.http.get<void>(`${this.budgetTrackingUrl}/Clear?date=${date.toISOString()}`);
  }
  closePeriod(date: Date) {
    return this.http.get<void>(`${this.budgetTrackingUrl}/Close?date=${date.toISOString()}`);
  }
  openPeriod(date: Date) {
    return this.http.get<void>(`${this.budgetTrackingUrl}/Open?date=${date.toISOString()}`);
  }
}
