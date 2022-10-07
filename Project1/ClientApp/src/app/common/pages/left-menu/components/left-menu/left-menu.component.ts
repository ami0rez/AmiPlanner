import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PageConstants } from 'src/app/common/constants/pages';
import { AuthenticationService } from 'src/common/services/authentication.service';
// import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.css']
})
export class LeftMenuComponent implements OnInit {
  visibleSidebar;
  pages = PageConstants;
  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  get activeRouter(): string {
    if (this.router.url?.length > 1) {
      var index = this.router.url?.indexOf('/') + 1;
      return this.router.url?.substring(index > 0 ? index : 0) + "/"
    } else {
      return this.router.url;
    }

  }
  ngOnInit() {
  }
  goto(event, page) {
    this.router.navigate([page])
    event.stopPropagation();
  }
  logout() {
    this.authenticationService.logout();
  }
  toggleMenu() {
    this.visibleSidebar = !this.visibleSidebar;
  }

}
