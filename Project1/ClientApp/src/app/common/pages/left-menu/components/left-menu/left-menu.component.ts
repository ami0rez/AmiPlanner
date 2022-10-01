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
  ngOnInit() {
  }
  goto(page){
    this.router.navigate([page])
  }
  gotoGoals(){
    this.router.navigate(["goals"])
  }
  logout(){
    this.authenticationService.logout();
  }
  toggleMenu(){
    this.visibleSidebar = !this.visibleSidebar;
  }

}
