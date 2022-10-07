import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-budget-track-item',
  templateUrl: './budget-track-item.component.html',
  styleUrls: ['./budget-track-item.component.css']
})
export class BudgetTrackItemComponent implements OnInit {

  @Input()
  subject: string;
  
  @Input()
  type: string;
  
  @Input()
  amount: string;

  @Input()
  editable = false;
  constructor() { }

  ngOnInit(): void {
  }


  edit(){
    this.setEditableMode(true);
  }

  save(){
    this.setEditableMode(false);
  }
  
  cancel(){
    this.setEditableMode(false);
  }
  setEditableMode(value) {
    this.editable = value;
  }

}
