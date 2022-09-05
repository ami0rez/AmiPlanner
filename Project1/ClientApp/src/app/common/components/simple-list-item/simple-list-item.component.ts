import { ListItem } from './../../models/list-item';
import { Colors } from './../../constants/colors';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-simple-list-item',
  templateUrl: './simple-list-item.component.html',
  styleUrls: ['./simple-list-item.component.css']
})
export class SimpleListItemComponent implements OnInit {

  @Input() item: ListItem;
  @Input() editable: boolean = true;

  @Output() itemClick: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemDelete: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemRenamed: EventEmitter<any> = new EventEmitter<any>();

  editing: boolean;

  showControls: boolean = false;
  appColors = Colors;
  constructor() { }

  ngOnInit(): void {
  }

  handleClick(event): void {
    this.itemClick.emit();
    event.stopPropagation();
  }

  handleOnDelete(event): void {
    this.itemDelete.emit();
    event.stopPropagation();
  }


  stopPropagation(event): void {
    event.stopPropagation();
  }
  renameProject(event): void {
    if (this.editable) {
      this.editing = true;
      event.stopPropagation();
    }
  }
  cancelRenameProject(): void {
    this.editing = false;
  }

  handleProjectRename(event): void {
    this.itemRenamed.emit(event.target.value);
    this.editing = false;
  }

  setShowControls(show): void {
    this.showControls = show;
  }
}
