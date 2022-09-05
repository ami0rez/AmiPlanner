import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LoginPage } from '../../models/login-page';
import { LoginManagerService } from './login-manager.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  pageObject: LoginPage = new LoginPage();
  
  loading = false;
  userNameRequired = $localize`:@@login.userNameError: userNameError`;
  passWordRequired = $localize`:@@login.passWordError: passWordError`;

  constructor(
    private route: ActivatedRoute,
    private loginManager: LoginManagerService
  ) {}

  ngOnInit(): void {
    this.pageObject.data.returnUrl =
      this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  /**
   *  @description login 
   */
  async login() {
    await this.loginManager.login(this.pageObject);
  }
}
