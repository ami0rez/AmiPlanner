import { ListItem } from './../../../../common/models/list-item';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { BudgetTrackItem } from '../../models/budget-track-item';

@Component({
  selector: 'app-budget-track-item',
  templateUrl: './budget-track-item.component.html',
  styleUrls: ['./budget-track-item.component.css']
})
export class BudgetTrackItemComponent implements OnInit {

  @Input()
  item: BudgetTrackItem = new BudgetTrackItem();

  clonedItem: BudgetTrackItem = new BudgetTrackItem();


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

  @Output()
  onSave: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onCancel: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onEdit: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();
  @Output()
  onDelete: EventEmitter<BudgetTrackItem> = new EventEmitter<BudgetTrackItem>();

  constructor() { }

  ngOnInit(): void {
  }


  edit() {
    this.setEditableMode(true);
    this.clonedItem = { ...this.item }
    this.onEdit.emit(this.item);
  }

  save() {
    this.onSave.emit({ ... this.item });
    console.log('save');
    
    this.item = new BudgetTrackItem();
  }

  cancel() {
    this.setEditableMode(false);
    this.item = { ...this.clonedItem }
    this.onCancel.emit({ ... this.item });
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
