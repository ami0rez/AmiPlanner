import { BudgetTrackerResponse } from './budget-tracker-response';
import { BudgetDashboardResponse } from './budget-dashboard';

export class BudgetData{
  budgetTrackingDate: Date = new Date();
  budgetTracker: BudgetTrackerResponse = new BudgetTrackerResponse();
  dashboard : BudgetDashboardResponse = new BudgetDashboardResponse();
}