import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarModule } from 'primeng/calendar';
import {TabViewModule} from 'primeng/tabview';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import {InputNumberModule} from 'primeng/inputnumber';
import {DropdownModule} from 'primeng/dropdown';
import {CheckboxModule} from 'primeng/checkbox';
import {ButtonModule} from 'primeng/button';
import {SelectButtonModule} from 'primeng/selectbutton';

import { BudgetPlannerComponent } from './budget-planner/components/budget-planner/budget-planner.component';
import { BudgetPlansComponent } from './budget-planner/components/budget-plans/budget-plans.component';
import { BudgetTrackItemComponent } from './budget-planner/components/budget-track-item/budget-track-item.component';
import { BudgetTrackerComponent } from './budget-planner/components/budget-tracker/budget-tracker.component';
import { BudgetRoutingModule } from './budget-planner/budget-routing.module';





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
    CheckboxModule,
    ButtonModule,
    SelectButtonModule
  ]
})
export class BudgetModule { }
