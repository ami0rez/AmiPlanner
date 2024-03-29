import { PageConstants } from './../../../common/constants/pages';
import { ListItem } from './../../../common/models/list-item';
import { FolderItem } from './../../models/folder/folder-item';
import { GoalPage } from './../../models/goal-page';
import { Component, OnInit } from '@angular/core';
import { GoalManagerService } from '../../services/goal-manager.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BreadCrumbService } from 'src/app/common/services/breadcrumb.service';

@Component({
  selector: 'app-goal-editor',
  templateUrl: './goal-editor.component.html',
  styleUrls: ['./goal-editor.component.css']
})
export class GoalEditorComponent implements OnInit {
  pageObject = new GoalPage();
  constructor(private goalManagerService: GoalManagerService,
    private breadCrumbService: BreadCrumbService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
  async ngOnInit() {
    this.breadCrumbService.setBreadcumbItem({
      label: 'Goals',
      url: PageConstants.goaolUrl
    })
    const id = this.route.snapshot.paramMap.get('id');
    await this.goalManagerService.loadFolder(this.pageObject, id);
    this.goalManagerService.addCurrentToPath(this.pageObject);
  }

  handleSearchChange(value) {
    //setsearchValue(value);
  };

  /*
   * handle search value change
   */
  handleFilter(value) {
    //setFilterValue(value);
  };


  /*
   * handle search value change
   */
  async handleAddGoal(goal) {
    await this.goalManagerService.createGoal(this.pageObject, goal);
  };

  /*
   * handle search value change
   */
  async handleAddFolder(folder) {
    await this.goalManagerService.createFolder(this.pageObject, folder);
  };

  /*
   * handle search value change
   */
  handleSort(value) {
    // setSortValue(value);
  };

  async onCardItemClick(item: FolderItem) {
    if (item.folder) {
      await this.goalManagerService.loadFolder(this.pageObject, item.value);
      this.goalManagerService.addCurrentToPath(this.pageObject);
    } else {
      this.router.navigate([PageConstants.projectUrl, item.value])
    }
  }
  async onCardItemDelete(item: FolderItem) {
    if (item.folder) {
      await this.goalManagerService.deleteFolder(this.pageObject, item.value);
    } else {
      await this.goalManagerService.deleteGoal(this.pageObject, item.value);
    }
  }

  async breadCrumbChange(item: ListItem) {
    await this.goalManagerService.loadFolder(this.pageObject, item.value);
    this.goalManagerService.removePathUntil(this.pageObject, item.value);
  }
}
