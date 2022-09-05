import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PageConstants } from 'src/app/common/constants/pages';
// import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.css']
})
export class LeftMenuComponent implements OnInit {
  visibleSidebar1;
  pages = PageConstants;
  constructor(private router: Router) { }
  ngOnInit() {
  }
  goto(page){
    this.router.navigate([page])
    this.visibleSidebar1 = false;
  }

}
