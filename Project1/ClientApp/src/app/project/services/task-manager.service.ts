import { DailyTasksPage } from './../../daily-tasks/models/daily-tasks-page';
import { TaskFilterQuery } from './../../daily-tasks/models/task-filter-query';
import { TaskConstants } from './../models/task/task-constants';
import { TaskUpdateQuery } from './../models/task/task-update-query';
import { lastValueFrom } from 'rxjs';
import { Injectable } from '@angular/core';
import { ProjectPage } from '../models/project-page';
import { TaskService } from './task.service';
import { TaskCreateQuery } from '../models/task/task-create-query';
import { TaskStateEnum } from '../models/task/task-state-enum';

@Injectable({
  providedIn: 'root'
})
export class TaskManagerService {
  constructor(private readonly taskService: TaskService) { }


  async filterTasks(pageObject: DailyTasksPage, query: TaskFilterQuery) {
    pageObject.loading = true;
    const result = await lastValueFrom(this.taskService.filter(query));
    pageObject.data.tasks = result;
    this.calculateTodayStatistics(pageObject);
    pageObject.loading = false;
  }
  async calculateTodayStatistics(pageObject: DailyTasksPage) {
    pageObject.loading = true;
    const { tasks } = pageObject.data;
    pageObject.data.todayStatistics = {
      abandonnedTasks: tasks?.filter(task => task?.state === TaskStateEnum.Abandoned)?.length ?? 0,
      doingTasks: tasks?.filter(task => task?.state === TaskStateEnum.Doing)?.length ?? 0,
      doneTasks: tasks?.filter(task => task?.state === TaskStateEnum.Done)?.length ?? 0,
      onHoldTasks: tasks?.filter(task => task?.state === TaskStateEnum.Hold)?.length ?? 0,
      todoTasks: tasks?.filter(task => task?.state === TaskStateEnum.Todo)?.length ?? 0,
    }
    pageObject.loading = false;
  }
  async createTask(pageObject: ProjectPage, name: string) {
    pageObject.loadingTask = true;
    const query: TaskCreateQuery = {
      name: name,
      projectId: pageObject.selectedProjectId,
    }
    const result = await lastValueFrom(this.taskService.createTask(query));
    pageObject.data.selectedProject.tasks = [...(pageObject?.data?.selectedProject?.tasks ?? []), result]
    this.filterAndSortTasksByPriority(pageObject);
    pageObject.loadingTask = false;
  }
  async deleteTask(pageObject: ProjectPage, id: string) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.deleteTask(id));
    pageObject.data.selectedProject.tasks = pageObject.data.selectedProject.tasks.filter(task => task.id != id);
    this.filterAndSortTasksByPriority(pageObject);
    pageObject.loadingTask = false;
  }

  async updateTaskState(pageObject: ProjectPage | DailyTasksPage, id: string, state: TaskStateEnum) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.updateTaskState(id, state));
    pageObject.loadingTask = false;
  }
  async updateTaskDate(pageObject: ProjectPage | DailyTasksPage, id: string, date: Date) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.updateTaskDate(id, date?.toISOString()));
    pageObject.loadingTask = false;
  }

  async updateTaskRepeat(pageObject: ProjectPage | DailyTasksPage, id: string, state: TaskStateEnum) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.updateTaskRepeat(id, state));
    pageObject.loadingTask = false;
  }

  async updateTaskPriority(pageObject: ProjectPage, id: string, priority: number) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.updateTaskPriority(id, priority));
    this.filterAndSortTasksByPriority(pageObject);
    pageObject.loadingTask = false;
  }


  async filterAndSortTasksByPriority(pageObject: any) {
    if (!pageObject.data.selectedProject) {
      return;
    }
    let filtered = [...pageObject.data.selectedProject.tasks];
    if (pageObject?.taskSearchFilter?.searchValue) {
      filtered = filtered.filter(({ name }) => name.toLowerCase().includes(pageObject.taskSearchFilter.searchValue.toLowerCase()) ||
        pageObject.taskSearchFilter.searchValue.toLowerCase().includes(name.toLowerCase()))
    }
    if (pageObject?.taskSearchFilter?.state?.value || pageObject?.taskSearchFilter?.state?.value === 0) {
      filtered = filtered.filter(({ state }) => state === pageObject?.taskSearchFilter?.state?.value)
    }
    if (pageObject?.taskSearchFilter?.sortBy?.value) {
      switch (pageObject?.taskSearchFilter?.sortBy?.value) {
        case TaskConstants.PriorityDesc:
          filtered = filtered.sort(({ priority: a }, { priority: b }) => b - a);
          break;
        case TaskConstants.PriorityAsc:
          filtered = filtered.sort(({ priority: a }, { priority: b }) => a - b);
          break;
        case TaskConstants.NameDesc:
          filtered = filtered.sort(({ state: a }, { state: b }) => a !== b ? a < b ? -1 : 1 : 0);
          break;
        case TaskConstants.NameAsc:
          filtered = filtered.sort(({ state: a }, { state: b }) => a !== b ? a > b ? -1 : 1 : 0);
          break;
        case TaskConstants.StateDesc:
          filtered = filtered.sort(({ state: a }, { state: b }) => b - a);
          break;
        case TaskConstants.StateAsc:
          filtered = filtered.sort(({ state: a }, { state: b }) => a - b);
          break;
      }
    } else {
      filtered = filtered.sort(({ priority: a }, { priority: b }) => b - a);
    }
    pageObject.data.filteredTasks = filtered;
  }


  async updateTask(pageObject: ProjectPage | DailyTasksPage, id: string, task: TaskUpdateQuery) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.updateTask(id, task));
    pageObject.loadingTask = false;
  }


  async updateTaskDescription(pageObject: ProjectPage | DailyTasksPage, id: string, task: TaskUpdateQuery) {
    pageObject.loadingTask = true;
    await lastValueFrom(this.taskService.updateTaskDescription(id, task));
    pageObject.loadingTask = false;
  }


  async openTask(pageObject: ProjectPage | DailyTasksPage, id: string, daily = false) {
    if (pageObject.data.loadedTasks?.some(task => task.id === id)) {
      pageObject.data.selectedTask = pageObject.data.loadedTasks.find(task => task.id === id)
    } else {
      const result = await lastValueFrom(this.taskService.getTaskById(id));
      pageObject.data.loadedTasks = [...(pageObject?.data?.loadedTasks ?? []), result];
      pageObject.data.selectedTask = result;
      pageObject.showTaskContent = true;
    }
  }

  async openDailyTask(pageObject: ProjectPage |DailyTasksPage, id: string) {
    if (pageObject.data.loadedTasks?.some(task => task.id === id)) {
      pageObject.data.selectedTask = pageObject.data.loadedTasks.find(task => task.id === id)
    } else {
      const result = await lastValueFrom(this.taskService.getDailyTaskById(id));
      pageObject.data.loadedTasks = [...(pageObject?.data?.loadedTasks ?? []), result];
      pageObject.data.selectedTask = result;
      result.historyVersions = result.historyVersions.sort(version => new Date(version.date) < new Date(version.date) ? 1 : -1)
      pageObject.showTaskContent = true;
    }
  }

  closeOpnedTask(pageObject: ProjectPage | DailyTasksPage) {
    pageObject.data.selectedTask = undefined;
    pageObject.showTaskContent = false;
  }
}
