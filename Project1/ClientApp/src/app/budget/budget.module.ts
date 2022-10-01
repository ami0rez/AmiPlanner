import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BudgetPlannerComponent } from './budget-planner/components/budget-planner/budget-planner.component';
import { BudgetRoutingModule } from './budget-planner/budget-routing.module';



@NgModule({
  declarations: [
    BudgetPlannerComponent
  ],
  imports: [
    BudgetRoutingModule,
    CommonModule
  ]
})
export class BudgetModule { }
