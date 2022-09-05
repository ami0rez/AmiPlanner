import { TaskStateEnum } from "./task-state-enum";

export class TaskListItemResponse {
  id: string;
  name: string;
  projectId: string;
  state: TaskStateEnum;
  date: Date;
  everyday: boolean;
  priority: number;
}