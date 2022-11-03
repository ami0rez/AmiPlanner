import { Component, Input, OnInit } from '@angular/core';
import { BudgetPage } from '../../models/budget-page';
import { BudgetPlannerManagerService } from '../../services/budget-planner-manager.service';

@Component({
  selector: 'app-budget-plans',
  templateUrl: './budget-plans.component.html',
  styleUrls: ['./budget-plans.component.css']
})
export class BudgetPlansComponent implements OnInit {
  
  @Input()
  pageObject: BudgetPage;
  constructor(private readonly budgetPlannerManagerService: BudgetPlannerManagerService) { }

  async ngOnInit() {
    this.budgetPlannerManagerService.initTypeOptions(this.pageObject);
  }

  async savePlan(item) {
    await this.budgetPlannerManagerService.saveBudgetPlan(this.pageObject, item);
  }


  async deletePlan(item) {
    await this.budgetPlannerManagerService.deleteBudgetPlan(this.pageObject, item);
  }

}
