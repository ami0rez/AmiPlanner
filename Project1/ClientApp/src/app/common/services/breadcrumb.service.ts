import { Injectable } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Subject } from 'rxjs';
import { AppStateService } from './app-state.service';

@Injectable({
  providedIn: 'root'
})
export class BreadCrumbService {

  private readonly breadCrmbStateKey = 'BreadCrumb';
  state: {};
  constructor(private appStateService: AppStateService) { }
  private items: MenuItem[];
  homeItem: MenuItem = { label: 'Home', url: '/' }

  private menuItemsSub = new Subject<MenuItem[]>();
  public menuItemsChanged = this.menuItemsSub.asObservable();

  /*
  *  @description load breadcrmb state if existes if not get default
  */
  saveBreadCumb() {
    this.appStateService.writeItem(this.breadCrmbStateKey, this.items);
  }

  /*
  *  @description load breadcrmb state if existes if not get default
  */
  loadBreadCumb() {
    if (this.items) {
      return;
    }
    var stateItems = this.appStateService.readItem(this.breadCrmbStateKey);
    if (stateItems && Array.isArray(stateItems)) {
      this.setBreadCrumbItems(stateItems);
    } else {
      this.initBreadCrumb();
    }
  }


  /*
  *  @description get breadcrmb items
  */
  getBreadCumbItems() {
    if (!this.items) {
      this.items = [this.homeItem];
    }
    return this.items;
  }

  /*
  *  @description Initializes Breadcrumb
  */
  initBreadCrumb() {
    this.setBreadCrumbItems(this.getDefaultBreadCrumb());
  }

  /*
  *  @description Initializes Breadcrumb
  */
  getDefaultBreadCrumb() {
    return [this.homeItem];
  }

  /*
  *  @description Sets Breadcrumb items
  */
  setBreadCrumbItems(items) {
    this.items = [...items];
    this.notifyMenuItemsRefresh();
  }

  /*
  *  @description Notify that items of breadcumb did change
  */
  notifyMenuItemsRefresh() {
    this.menuItemsSub.next(this.items);
  }

  /*
  *  @description clears menu Items
  */
  clearBreadcumbItems() {
    this.setBreadCrumbItems([this.homeItem]);
  }

  /*
  *  @description add menu Item
  */
  addBreadcumbItem(item: MenuItem) {
    if (!this.items) {
      this.loadBreadCumb();
    }
    const itemInBreadCumb = this.items.find(menuItem => menuItem.label === item.label && menuItem.url === item.url);
    if (itemInBreadCumb) {
      const itemIndex = this.items.indexOf(itemInBreadCumb);
      this.items.splice(itemIndex);
    } else {
      this.items.push(item);
    }
    this.setBreadCrumbItems([...this.items]);
  }

  /*
  *  @description reitini breadcrumb and add menu Item
  */
  setBreadcumbItem(item: MenuItem) {
    this.items = this.getDefaultBreadCrumb();
    this.items.push(item);
    this.setBreadCrumbItems([...this.items]);
  }

}
