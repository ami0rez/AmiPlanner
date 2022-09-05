import { ProjectData } from './project-data';
import { TaskSearchFilter } from './task/task-search-filter';
export class ProjectPage {
  data: ProjectData = new ProjectData();
  selectedProjectId : string;
  loading: boolean;
  loadingTask: boolean;
  showTaskContent: boolean;
  taskSearchFilter: TaskSearchFilter = new TaskSearchFilter();
}