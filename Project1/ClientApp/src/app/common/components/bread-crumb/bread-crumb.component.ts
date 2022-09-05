import { ListItem } from './../../models/list-item';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css']
})
export class BreadCrumbComponent implements OnInit {

  @Input() items: ListItem[] = [];
  @Output() itemClick: EventEmitter<ListItem> = new EventEmitter<ListItem>();
  constructor() { }

  ngOnInit(): void {
  }

  handleItemClick(item: ListItem, emit) {
    if(emit){
      this.itemClick.emit(item);
    }
  }
}
