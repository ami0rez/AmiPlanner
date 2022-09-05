import { TaskStateEnum } from "./task-state-enum";

export class TaskItemResponse {
  name: string;
  id: string;
  description: string;
  projectId: string;
  state: TaskStateEnum;
  date: Date;
  everyday: boolean;
  estimated: number;
  completed: number;
  rest: number;
  priority: number;
  historyVersions: TaskItemResponse[];
}