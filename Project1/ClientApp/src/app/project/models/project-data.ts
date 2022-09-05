import { TaskListItemResponse } from './task/task-list-item-response';
import { ProjectItemResponse } from './project-item-response';
import { ListItem } from './../../common/models/list-item';
import { GoalListItemResponse } from './../../goal/models/goal-list-item-response';
import { TaskItemResponse } from './task/task-item-response';
export class ProjectData {
  currentGoal: GoalListItemResponse;
  projectItems: ListItem[] = [];
  openedProjects: ProjectItemResponse[] = [];
  selectedProject: ProjectItemResponse;
  filteredTasks: TaskListItemResponse[];
  selectedTask: TaskItemResponse;
  loadedTasks: TaskItemResponse[] = [];
}