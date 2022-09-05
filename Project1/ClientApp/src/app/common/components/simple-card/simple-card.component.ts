import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-simple-card',
  templateUrl: './simple-card.component.html',
  styleUrls: ['./simple-card.component.css']
})
export class SimpleCardComponent implements OnInit {

  showDelete: boolean;

  @Input() title;
  @Input() icon;
  @Input() iconColor;

  @Output() itemClick: EventEmitter<any> = new EventEmitter<any>();
  @Output() itemDelete: EventEmitter<any> = new EventEmitter<any>();
  constructor() { }

  ngOnInit(): void {
  }

  handleClick(): void {
    this.itemClick.emit();
  }

  handleDelete(event): void {
    event.stopPropagation();
    this.itemDelete.emit();
  }
  setShowDelete(show): void {
    this.showDelete = show;
  }
}
