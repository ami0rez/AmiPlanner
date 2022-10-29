import { BudgetTrackItem } from './budget-track-item';
export class BudgetTrackerResponse{
  incom: BudgetTrackItem[] = [];
  spentNeeds: BudgetTrackItem[] = [];
  spentWants: BudgetTrackItem[] = [];
  savings: BudgetTrackItem[] = [];
  plans: BudgetTrackItem[] = [];
  
  percentIncom: Number;
  percentSpentWants: Number;
  percentSpentNeeds: Number;
  percentSpent: Number;
  percentSavings: Number;
  totalIncom: Number;
  totalSpentWants: Number;
  totalSpentNeeds: Number;
  totalSpent: Number;
  totalSavings: Number;
  availableIncom: Number;
  availableSpentWants: Number;
  availableSpentNeeds: Number;
  availableSavings: Number;
  periodClosed: boolean;
}