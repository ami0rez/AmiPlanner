import { TaskFilterOptions } from './task-filter-options';
import { DailyTasksData } from "./daily-tasks-data";
import { TaskFilterQuery } from "./task-filter-query";

export class DailyTasksPage {
  data: DailyTasksData = new DailyTasksData();
  loading: boolean;
  loadingTask: boolean;
  showTaskContent: boolean;
  showTaskSubfilters: boolean;
  taskSearchFilter: TaskFilterQuery = new TaskFilterQuery();
  taskFilterOptions: TaskFilterOptions = new TaskFilterOptions();
}