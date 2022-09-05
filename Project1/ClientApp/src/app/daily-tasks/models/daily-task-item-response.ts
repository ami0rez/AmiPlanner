import { TaskItemResponse } from './../../project/models/task/task-item-response';

export class DailyTaskItemResponse extends TaskItemResponse {
  folderName: string;
  folderGoals: number;
  folderProjects: number;
  folderTasks: number;
  goalName: string;
  goalProjects: number;
  goalTasks: number;
  projectName: string;
  normalTasks: number;
  routineTasks: number;
  todaysTasks: number;
  todoTasks: number;
  doingTasks: number;
  abandonnedTasks: number;
  onHoldTasks: number;
  doneTasks: number;
}