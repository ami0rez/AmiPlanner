import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/common/services/authentication.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css'],
})
export class LogoutComponent implements OnInit {
  constructor(private authService: AuthenticationService) {}

  ngOnInit() {}

  /**
   *  @description Start authentication 
   */
  login() {
    this.authService.startAuthentication();
  }
}
