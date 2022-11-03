import { BudgetSpentItem } from './../../models/budget-spent-item';
import { ListItem } from './../../../../common/models/list-item';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { BudgetTrackItem } from '../../models/budget-track-item';
import { toUtcDate } from 'involys-common/common';

@Component({
  selector: 'app-budget-track-item',
  templateUrl: './budget-track-item.component.html',
  styleUrls: ['./budget-track-item.component.css']
})
export class BudgetTrackItemComponent implements OnInit {

  @Input()
  item: BudgetTrackItem = new BudgetTrackItem();

  @Input()
  options: ListItem[];

  @Input()
  typeOptions: ListItem[];

  @Input()
  editable = false;

  @Input()
  creator = false;

  @Input()
  useCategory = true;

  @Input()
  planner = false;

  @Input()
  canPay = false;

  @Output()
  onPay: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onRefund: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onSave: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onCancel: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onEdit: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onDelete: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();

  @Output()
  onSaveSpent: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onCancelSpent: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onEditSpent: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();
  @Output()
  onDeleteSpent: EventEmitter<BudgetSpentItem> = new EventEmitter<BudgetSpentItem>();

  clonedItem: BudgetTrackItem = new BudgetTrackItem();
  showSpendings = false;
  constructor() { }

  ngOnInit(): void {
  }


  edit() {
    this.setEditableMode(true);
    this.clonedItem = { ...this.item }
    this.item.date = toUtcDate(this.item.date);
    this.onEdit.emit(this.item);
  }

  pay() {
    this.onPay.emit(this.item);
  }

  refund() {
    this.onRefund.emit(this.item);
  }

  save() {
    if (this.planner && !this.item.repeat) {
      this.item.date = toUtcDate(this.item.date);
    }
    this.onSave.emit({ ... this.item });
    this.item = new BudgetTrackItem();
  }

  saveSpentItem(spentItem: BudgetSpentItem) {
    spentItem.parentId = this.item.id;
    this.onSaveSpent.emit({ ...spentItem });
  }

  cancel() {
    this.setEditableMode(false);
    this.item = { ...this.clonedItem }
    this.onCancel.emit({ ... this.item });
  }

  toggleSpendings() {
    this.showSpendings = !this.showSpendings;
  }

  remove() {
    this.setEditableMode(false);
    this.onDelete.emit({ ... this.item });
  }

  setEditableMode(value) {
    this.editable = value;
  }

  typeChanged() {
    this.item.categoryLabel = this.options.find(opt => opt.value === this.item.categoryId)?.label;
  }

}
