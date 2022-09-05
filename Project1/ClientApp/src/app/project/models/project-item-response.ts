import { TaskListItemResponse } from "./task/task-list-item-response";

export class ProjectItemResponse {
  id: string;
  name: string;
  folderId: string;
  tasks: TaskListItemResponse[] = [];
}