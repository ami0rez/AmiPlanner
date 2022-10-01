import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthenticationService } from 'src/common/services/authentication.service';
import { BreadCrumbService } from './common/services/breadcrumb.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  authSubscription: Subscription;
  connectionValid = false;
  constructor(
    private authenticationService: AuthenticationService,
    private breadCrumbService: BreadCrumbService,
  ) {}

  ngOnDestroy(): void {
    if(this.authSubscription){
      this.authSubscription.unsubscribe();
      this.breadCrumbService.saveBreadCumb();
    }
  }
  ngOnInit(): void {
    this.connectionValid = this.authenticationService.userAuthenticated;
    this.authSubscription = this.authenticationService.authChanged.subscribe(() => {
      this.connectionValid = this.authenticationService.userAuthenticated;
    });
  }
}
