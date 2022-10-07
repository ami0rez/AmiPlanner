import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BudgetPlannerComponent } from './budget-planner/components/budget-planner/budget-planner.component';
import { BudgetRoutingModule } from './budget-planner/budget-routing.module';
import { CalendarModule } from 'primeng/calendar';
import {TabViewModule} from 'primeng/tabview';
import { BudgetTrackerComponent } from './budget-planner/components/budget-tracker/budget-tracker.component';
import { BudgetTrackItemComponent } from './budget-planner/components/budget-track-item/budget-track-item.component';
import {InputNumberModule} from 'primeng/inputnumber';
import {DropdownModule} from 'primeng/dropdown';





@NgModule({
  declarations: [
    BudgetPlannerComponent,
    BudgetTrackerComponent,
    BudgetTrackItemComponent
  ],
  imports: [
    BudgetRoutingModule,
    CommonModule,
    CalendarModule,
    TabViewModule,
    InputNumberModule,
    DropdownModule
  ]
})
export class BudgetModule { }
