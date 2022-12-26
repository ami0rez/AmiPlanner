import { TaskItemResponse } from './../../models/task/task-item-response';
import {
  Component,
  EventEmitter,
  Input,
  Output,
  OnChanges,
  ViewChild,
  AfterViewInit,
} from '@angular/core';
import { Editor } from 'primeng/editor';
// import TaskList from 'quill-task-list';

@Component({
  selector: 'app-project-task-description',
  templateUrl: './project-task-description.component.html',
  styleUrls: ['./project-task-description.component.css'],
})
export class ProjectTaskDescriptionComponent
  implements OnChanges, AfterViewInit
{
  @ViewChild(Editor) editor: Editor;

  @Input() task: TaskItemResponse;

  @Output() close: EventEmitter<any> = new EventEmitter<any>();
  @Output() change: EventEmitter<TaskItemResponse> =
    new EventEmitter<TaskItemResponse>();
  taskStates = ['todo', 'doing', 'done', 'abandoned', 'hold', 'todo'];
  unknownState = 'unknown';
  selectedTask: TaskItemResponse;
  editDisabled: boolean;
  public modules = {
      toolbar: {
        container: [
          [{ placeholder: ['GuestName', '[HotelName]'] }], // my custom dropdown
          ['bold', 'italic', 'underline', 'strike'], // toggled buttons
          ['blockquote', 'code-block'],

          [{ header: 1 }, { header: 2 }], // custom button values
          [{ list: 'ordered' }, { list: 'bullet' }],
          [{ script: 'sub' }, { script: 'super' }], // superscript/subscript
          [{ indent: '-1' }, { indent: '+1' }], // outdent/indent
          [{ direction: 'rtl' }], // text direction

          [{ size: ['small', false, 'large', 'huge'] }], // custom dropdown
          [{ header: [1, 2, 3, 4, 5, 6, false] }],

          [{ color: [] }, { background: [] }], // dropdown with defaults from theme
          [{ font: [] }],
          [{ align: [] }],

          ['clean'], // remove formatting button
        ],
        handlers: {
          placeholder: function (value) {
            if (value) {
              const cursorPosition = this.quill.getSelection().index;
              this.quill.insertText(cursorPosition, value);
              this.quill.setSelection(cursorPosition + value.length);
            }
          },
        },
      },
    };

  constructor() {}

  ngAfterViewInit(): void {
    // this.editor.getQuill().register('task-list', TaskList);
  }
  ngOnChanges(): void {
    if (this.task) {
      this.selectedTask = this.task;
    } else {
      this.selectedTask = new TaskItemResponse();
    }
  }

  setSelectedTask(task) {
    this.selectedTask = task.version;
    this.editDisabled = true;
  }

  setDefaultSeelectedTask() {
    this.selectedTask = this.task;
    this.editDisabled = false;
  }
  handleTaskUpdate(event): void {
    this.change.emit({ ...this.task, description: event.htmlValue });
  }

  handleOnClose() {
    this.close.emit();
  }

  getClassName(): string {
    if (
      this.task?.state != null &&
      this.task?.state >= 0 &&
      this.task?.state < this.taskStates.length
    ) {
      return this.taskStates[this.task.state];
    } else {
      return this.unknownState;
    }
  }
}
