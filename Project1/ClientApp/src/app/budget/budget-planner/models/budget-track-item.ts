import { BudgetTypes } from "./enums/budget-type";

export class BudgetTrackItem{
  id: string;
  subject: string;
  repeat: string;
  date: any;
  ammount: number;
  type: BudgetTypes;
  categoryId: BudgetTypes;
  categoryLabel: string;
  paid: boolean;
}