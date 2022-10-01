import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SidebarModule } from 'primeng/sidebar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { AvatarModule } from 'primeng/avatar';
import {TieredMenuModule} from 'primeng/tieredmenu';
import {TooltipModule} from 'primeng/tooltip';


import { SimpleCardComponent } from './components/simple-card/simple-card.component';
import { LoadingComponent } from './components/loading/loading.component';
import { BreadCrumbComponent } from './components/bread-crumb/bread-crumb.component';
import { SimpleListItemComponent } from './components/simple-list-item/simple-list-item.component';
import { LeftMenuComponent } from './pages/left-menu/components/left-menu/left-menu.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';



@NgModule({
  declarations: [
    SimpleCardComponent,
    LoadingComponent,
    BreadCrumbComponent,
    SimpleListItemComponent,
    LeftMenuComponent,
    NavBarComponent
  ],
  imports: [
    CommonModule,
    SidebarModule,
    BrowserAnimationsModule,
    ButtonModule,
    BreadcrumbModule,
    AvatarModule,
    TieredMenuModule,
    TooltipModule
  ],
  exports:[
    SimpleCardComponent,
    LoadingComponent,
    BreadCrumbComponent,
    SimpleListItemComponent,
    LeftMenuComponent,
    NavBarComponent
  ]
})
export class SharedModule { }
