import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/security/common/auth.guard';
import { BudgetPlannerComponent } from './components/budget-planner/budget-planner.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: BudgetPlannerComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BudgetRoutingModule { }
