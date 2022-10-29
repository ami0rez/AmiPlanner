import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { PeriodService } from './period.service';

@Injectable({
  providedIn: 'root'
})
export class periodManagerService {
  constructor(private periodService: PeriodService) { }

  async initPeriod(period: Date) {
    await lastValueFrom(this.periodService.initPeriod(period));
  }

  async clearPeriod(period: Date) {
    await lastValueFrom(this.periodService.clearPeriod(period));
  }

  async closePeriod(period: Date) {
    await lastValueFrom(this.periodService.closePeriod(period));
  }

  async openPeriod(period: Date) {
    await lastValueFrom(this.periodService.openPeriod(period));
  }
}
