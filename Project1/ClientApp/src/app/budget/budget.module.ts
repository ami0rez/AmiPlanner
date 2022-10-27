import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BudgetPlannerComponent } from './budget-planner/components/budget-planner/budget-planner.component';
import { BudgetRoutingModule } from './budget-planner/budget-routing.module';
import { CalendarModule } from 'primeng/calendar';
import {TabViewModule} from 'primeng/tabview';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { BudgetTrackerComponent } from './budget-planner/components/budget-tracker/budget-tracker.component';
import { BudgetTrackItemComponent } from './budget-planner/components/budget-track-item/budget-track-item.component';
import {InputNumberModule} from 'primeng/inputnumber';
import {DropdownModule} from 'primeng/dropdown';
import {CheckboxModule} from 'primeng/checkbox';
import { BudgetPlansComponent } from './budget-planner/components/budget-plans/budget-plans.component';





@NgModule({
  declarations: [
    BudgetPlannerComponent,
    BudgetTrackerComponent,
    BudgetTrackItemComponent,
    BudgetPlansComponent
  ],
  imports: [
    BudgetRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    CalendarModule,
    TabViewModule,
    InputNumberModule,
    DropdownModule,
    CheckboxModule
  ]
})
export class BudgetModule { }
