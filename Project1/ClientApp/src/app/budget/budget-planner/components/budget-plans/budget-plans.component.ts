import { Component, OnInit } from '@angular/core';
import { BudgetPage } from '../../models/budget-page';
import { BudgetPlannerManagerService } from '../../services/budget-planner-manager.service';
import { BudgetTrackManagerService } from '../../services/budget-tracker-manager.service';

@Component({
  selector: 'app-budget-plans',
  templateUrl: './budget-plans.component.html',
  styleUrls: ['./budget-plans.component.css']
})
export class BudgetPlansComponent implements OnInit {

  pageObject: BudgetPage = new BudgetPage();
  constructor(private readonly budgetTrackManagerService: BudgetTrackManagerService,
    private readonly budgetPlannerManagerService: BudgetPlannerManagerService) { }

  async ngOnInit() {
    await this.budgetTrackManagerService.loadOptions(this.pageObject);
    await this.budgetPlannerManagerService.getPlans(this.pageObject);
    this.budgetPlannerManagerService.initTypeOptions(this.pageObject);
  }

  async savePlan(item) {
    this.verifyDate(item);
    await this.budgetPlannerManagerService.saveBudgetPlan(this.pageObject, item);
  }

  /*
  *  @description verify if item has date, if not add date
  */
  verifyDate(item) {
    if (!item.id) {
      item.date = new Date();
    }
  }


  async deletePlan(item) {
    await this.budgetPlannerManagerService.deleteBudgetPlan(this.pageObject, item);
  }

}
