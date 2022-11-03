import { ListItem } from './../../../common/models/list-item';
import { BudgetData } from './budget-data';
export class BudgetPage{
  data: BudgetData = new BudgetData();
  showPageDashboard = false;
  categoryOptions : ListItem[] = [];
  typeOptions : ListItem[] = [];
}