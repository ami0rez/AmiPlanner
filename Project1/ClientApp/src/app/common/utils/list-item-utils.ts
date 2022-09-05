import { ListItem } from './../models/list-item';
export class ListItemUtils {
  static addAllOption(list: ListItem[], id: string = null) {
    list.unshift({
      label: "All",
      value: id
    })
  }
}