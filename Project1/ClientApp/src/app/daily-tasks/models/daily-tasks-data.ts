import { TodayStatistics } from './today-statistics';
import { DailyTaskItemResponse } from './daily-task-item-response';
import { TaskFilterListItemResponse } from './task-filter-list-item-response';
export class DailyTasksData {
  tasks: TaskFilterListItemResponse[];
  loadedTasks: DailyTaskItemResponse[];
  selectedTask: DailyTaskItemResponse;
  todayStatistics:TodayStatistics;
}