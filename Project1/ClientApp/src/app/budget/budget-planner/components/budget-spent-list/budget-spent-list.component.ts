import { BudgetSpentItem } from './../../models/budget-spent-item';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-budget-spent-list',
  templateUrl: './budget-spent-list.component.html',
  styleUrls: ['./budget-spent-list.component.css']
})
export class BudgetSpentListComponent implements OnInit {

  @Input()
  value: BudgetSpentItem[]



  @Output()
  onSave: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onCancel: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onEdit: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onDelete: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  constructor() { }

  ngOnInit(): void {
  }

  handleSave(item: BudgetSpentItem) {
    this.onSave.emit(item);
  }

  handelDelete(item: BudgetSpentItem) {
    this.onDelete.emit(item);
  }
}
