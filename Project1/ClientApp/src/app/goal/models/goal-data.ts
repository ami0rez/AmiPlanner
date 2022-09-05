import { ListItem } from './../../common/models/list-item';
import { FolderItem } from './folder/folder-item';
import { FolderItemResponse } from './folder/folder-item-response';
export class GoalData {
  currenfFolder: FolderItemResponse;
  folderItems: FolderItem[] = [];
  currentpath: ListItem[] = [];
}