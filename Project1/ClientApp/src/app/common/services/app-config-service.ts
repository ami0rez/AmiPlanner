import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AppConfig } from './../models/app-config';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {

  private customHttpClient: HttpClient;
  appConfig: AppConfig;
  constructor(backend: HttpBackend) {
    this.customHttpClient = new HttpClient(backend);
  }

  async loadAppConfig() {
    return new Promise((resolve, reject) => {
      this.customHttpClient.get<AppConfig>('./assets/app.config.json').subscribe((value) => {
        this.appConfig = value;
        resolve(true);
      });
    });
  }
}
