import { TaskItemResponse } from './../../models/task/task-item-response';
import { Component, EventEmitter, Input, Output, OnChanges, ViewChild } from '@angular/core';
import { Editor } from 'primeng/editor';

@Component({
  selector: 'app-project-task-description',
  templateUrl: './project-task-description.component.html',
  styleUrls: ['./project-task-description.component.css']
})
export class ProjectTaskDescriptionComponent implements OnChanges {
  
  @ViewChild(Editor) editor:Editor;

  @Input() task: TaskItemResponse;

  @Output() close: EventEmitter<any> = new EventEmitter<any>();
  @Output() change: EventEmitter<TaskItemResponse> = new EventEmitter<TaskItemResponse>();
  taskStates = ["todo", "doing", "done", "abandoned", "hold", "todo"];
  unknownState = "unknown";
  selectedTask : TaskItemResponse;
  editDisabled: boolean;
  constructor() { }

  ngOnChanges(): void {
    if(this.task){
      this.selectedTask = this.task;
    }else{
      this.selectedTask = new TaskItemResponse();
    }
  }

  setSelectedTask(task){
    this.selectedTask = task.version;
    this.editDisabled =  true;
  }

  setDefaultSeelectedTask(){
    this.selectedTask = this.task;
    this.editDisabled =  false;
  }
  handleTaskUpdate(): void {
    this.change.emit(this.task);
  }

  handleOnClose(){
    this.close.emit();
  }
  
  getClassName(): string {
    if (this.task?.state != null && this.task?.state >= 0 && this.task?.state < this.taskStates.length) {
      return this.taskStates[this.task.state]
    } else {
      return this.unknownState;
    }
  }
}
