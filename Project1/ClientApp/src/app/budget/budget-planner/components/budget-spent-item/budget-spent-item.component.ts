import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { toUtcDate } from 'involys-common/common';
import { Constants } from 'src/app/common/global-constants';
import { BudgetSpentItem } from '../../models/budget-spent-item';

@Component({
  selector: 'app-budget-spent-item',
  templateUrl: './budget-spent-item.component.html',
  styleUrls: ['./budget-spent-item.component.css']
})
export class BudgetSpentItemComponent implements OnInit {

  @Input()
  item: BudgetSpentItem = new BudgetSpentItem();

  @Input()
  editable = false;

  @Input()
  creator = false;
  

  @Output()
  onSave: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onCancel: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onEdit: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onDelete: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();

  constructor() { }

  clonedItem: BudgetSpentItem = new BudgetSpentItem();
  today = new Date();
  datePattern = Constants.datePattern;

  ngOnInit(): void {
  }

  setEditableMode(value) {
    this.editable = value;
  }

  edit() {
    this.setEditableMode(true);
    this.clonedItem = { ...this.item }
    this.item.date = toUtcDate(this.item.date);
    this.onEdit.emit(this.item);
  }
  remove() {
    this.setEditableMode(false);
    this.onDelete.emit({ ... this.item });
  }
  save() {
    if (!this.item.id) {
      this.item.date = new Date();
    }
    this.item.date = toUtcDate(this.item.date);
    this.onSave.emit({ ... this.item });
    this.item = new BudgetSpentItem();
  }

  cancel() {
    this.setEditableMode(false);
    this.item = { ...this.clonedItem }
    this.onCancel.emit({ ... this.item });
  }

}
