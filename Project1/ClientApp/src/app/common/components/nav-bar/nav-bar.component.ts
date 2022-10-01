import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'involys-library';
import { AuthenticationService } from 'src/common/services/authentication.service';
import { PageConstants } from '../../constants/pages';
import { BreadCrumbService } from '../../services/breadcrumb.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit, OnDestroy {

  items: MenuItem[];
  breadcrmbItems: MenuItem[];
  breadcrumbSubscription: Subscription;
  constructor(
    private authenticationService: AuthenticationService,
    private breadCrumbService: BreadCrumbService,
    private router: Router) {
  }


  ngOnInit() {
    this.items = [
      {
        label: 'Logout',
        command: () => this.logout(),
      },
    ];
    this.loadBreadcrmb();

  }
  loadBreadcrmb() {
    this.breadcrmbItems = this.breadCrumbService.getBreadCumbItems();
    this.breadcrumbSubscription = this.breadCrumbService.menuItemsChanged.subscribe((value) => {
      this.breadcrmbItems = value
    });
  }
  ngOnDestroy() {
    if (this.breadcrumbSubscription) {
      this.breadcrumbSubscription.unsubscribe();
    }
  }

  toggleMenu() {
    this.router.navigate([PageConstants.homeUrl])
  }

  logout() {
    this.authenticationService.logout();
  }
}
