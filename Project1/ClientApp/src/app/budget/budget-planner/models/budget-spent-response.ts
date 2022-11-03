import { BudgetSpentItem } from './budget-spent-item';

export class BudgetSpentResponse{
  spendings: BudgetSpentItem[] = [];
  total: number;
}