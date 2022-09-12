import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'involys-library';
import { PageConstants } from '../../constants/pages';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  items: MenuItem[];
  constructor(private router: Router) {
   }


  ngOnInit() {
    this.items = [
      { label: 'Categories' },
      { label: 'Sports' },
      { label: 'Football' },
      { label: 'Countries' },
      { label: 'Spain' },
      { label: 'F.C. Barcelona' },
      { label: 'Squad' },
      { label: 'Lionel Messi', url: 'https://en.wikipedia.org/wiki/Lionel_Messi' }
    ];
  }

  toggleMenu(){
    this.router.navigate([PageConstants.homeUrl])
  }
}
