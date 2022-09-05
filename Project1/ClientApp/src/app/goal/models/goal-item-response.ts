import { ProjectListItemResponse } from './../../project/models/project-list-item-response';
export class GoalItemResponse {
  id: string;
  name: string;
  folderId: string;
  projects: ProjectListItemResponse[] = [];
}