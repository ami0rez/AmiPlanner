import { Component, OnInit } from '@angular/core';
import { BudgetPage } from '../../models/budget-page';
import { BudgetPlannerManagerService } from '../../services/budget-planner-manager.service';

import { BudgetTrackManagerService } from '../../services/budget-tracker-manager.service';

@Component({
  selector: 'app-budget-planner',
  templateUrl: './budget-planner.component.html',
  styleUrls: ['./budget-planner.component.css']
})
export class BudgetPlannerComponent implements OnInit {

  pageObject: BudgetPage = new BudgetPage();
  constructor(private readonly budgetTrackManagerService: BudgetTrackManagerService, 
    private readonly budgetPlannerManagerService: BudgetPlannerManagerService) { }

  async ngOnInit() {
    await this.budgetTrackManagerService.loadOptions(this.pageObject);
    await this.budgetPlannerManagerService.getPlans(this.pageObject);
    await this.budgetTrackManagerService.getTrackingItems(this.pageObject);
  }

  toggleDashboard() {
    this.pageObject.showPageDashboard = !this.pageObject.showPageDashboard;
  }

}
