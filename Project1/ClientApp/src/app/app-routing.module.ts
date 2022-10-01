import { ProjectEditorComponent } from './project/components/project-editor/project-editor.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoalEditorComponent } from './goal/componenets/goal-editor/goal-editor.component';
import { DailyTasksComponent } from './daily-tasks/components/daily-tasks/daily-tasks.component';
import { AuthGuard } from './security/common/auth.guard';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: DailyTasksComponent, canActivate: [AuthGuard] },
  { path: 'goals', pathMatch: 'full', component: GoalEditorComponent, canActivate: [AuthGuard] },
  { path: 'project/:id', pathMatch: 'full', component: ProjectEditorComponent, canActivate: [AuthGuard] },
  {
    path: 'security',
    loadChildren: () =>
      import('./security/security.module').then((mod) => mod.SecurityModule),
  },
  {
    path: 'budget',
    loadChildren: () =>
      import('./budget/budget.module').then((mod) => mod.BudgetModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
