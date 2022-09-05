import { GoalItemResponse } from './../goal-item-response';

export class FolderItemResponse {
  folders: FolderItemResponse[]
  goals: GoalItemResponse[]
  id: string
  name: string
  folderId: string
}