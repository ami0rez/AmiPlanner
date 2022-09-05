import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SidebarModule } from 'primeng/sidebar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';

import { SimpleCardComponent } from './components/simple-card/simple-card.component';
import { LoadingComponent } from './components/loading/loading.component';
import { BreadCrumbComponent } from './components/bread-crumb/bread-crumb.component';
import { SimpleListItemComponent } from './components/simple-list-item/simple-list-item.component';
import { LeftMenuComponent } from './pages/left-menu/components/left-menu/left-menu.component';



@NgModule({
  declarations: [
    SimpleCardComponent,
    LoadingComponent,
    BreadCrumbComponent,
    SimpleListItemComponent,
    LeftMenuComponent
  ],
  imports: [
    CommonModule,
    SidebarModule,
    BrowserAnimationsModule,
    ButtonModule
  ],
  exports:[
    SimpleCardComponent,
    LoadingComponent,
    BreadCrumbComponent,
    SimpleListItemComponent,
    LeftMenuComponent
  ]
})
export class SharedModule { }
