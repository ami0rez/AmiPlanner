import { Injectable } from '@angular/core';

import { MessageService } from 'primeng/api';
import { Constants } from './models/constants';
import { ErrorMessages } from './models/error-messages';


@Injectable({ providedIn: 'root' })
export class ErrorService {
  constructor(private messageService: MessageService) {}
  lifeTime = Constants.notificationLifeTime;
  showErrors(data): any {
    this.messageService.add({
      severity: 'error',
      summary: `${data.status}`,
      detail: `${data.reason}`,
      sticky: false,
      life: this.lifeTime,
    });
  }

  showServerErrors(data): any {
    let severity = 'error';
    let summary = ErrorMessages.error;
    switch (data.status) {
      case 0:
        severity = 'success';
        summary = ErrorMessages.success;
        break;
      case 1:
        severity = 'info';
        summary = ErrorMessages.info;
        break;
      case 2:
        severity = 'warn';
        summary = ErrorMessages.warning;
    }

    this.messageService.add({
      severity,
      summary,
      detail: `${data.reason}`,
      sticky: false,
      life: this.lifeTime,
    });
  }
}
