import { TaskListItemResponse } from './../../project/models/task/task-list-item-response';
export class TaskFilterListItemResponse extends TaskListItemResponse{
  projectName: string;
  goalName: string;
  folderName: string;
}