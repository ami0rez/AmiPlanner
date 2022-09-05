import { Component, Input, OnChanges } from '@angular/core';
import { DailyTaskItemResponse } from '../../models/daily-task-item-response';
import { TodayStatistics } from '../../models/today-statistics';

@Component({
  selector: 'app-daily-tasks-statistics',
  templateUrl: './daily-tasks-statistics.component.html',
  styleUrls: ['./daily-tasks-statistics.component.css']
})
export class DailyTasksStatisticsComponent implements OnChanges {
  @Input() task = new DailyTaskItemResponse();
  @Input() todayStatistics = new TodayStatistics();

  taskData: any;
  todayData: any;

  chartOptions: any;

  constructor() { }

  ngOnChanges() {
    this.taskData = {
      labels: ['Todo', 'Doing', 'Done', 'Abandonned', 'Hold'],
      datasets: [
        {
          data: [
            this.task?.todoTasks ?? 0, 
            this.task?.doingTasks ?? 0, 
            this.task?.doneTasks ?? 0, 
            this.task?.abandonnedTasks ?? 0, 
            this.task?.onHoldTasks ?? 0],
          backgroundColor: [
            "#FFE733AA",
            "#FF8C01",
            "#006B3E",
            "#ED2938",
            "#009ECE",
          ],
          hoverBackgroundColor: [
            "#FFE733",
            "#FF8C01AA",
            "#006B3EAA",
            "#ED2938AA",
            "#009ECEAA",
          ]
        }
      ]
    };
    this.todayData = {
      labels: ['Todo', 'Doing', 'Done', 'Abandonned', 'Hold'],
      datasets: [
        {
          data: [
            this.todayStatistics?.todoTasks ?? 0, 
            this.todayStatistics?.doingTasks ?? 0, 
            this.todayStatistics?.doneTasks ?? 0, 
            this.todayStatistics?.abandonnedTasks ?? 0, 
            this.todayStatistics?.onHoldTasks ?? 0],
          backgroundColor: [
            "#FFE733",
            "#FF8C01",
            "#006B3E",
            "#ED2938",
            "#009ECE",
          ],
          hoverBackgroundColor: [
            "#FFE733AA",
            "#FF8C01AA",
            "#006B3EAA",
            "#ED2938AA",
            "#009ECEAA",
          ]
        }
      ]
    };

    this.updateChartOptions();
  }

  updateChartOptions() {
    this.chartOptions = this.getLightTheme();
  }

  getLightTheme() {
    return {
      cutout: 70,
      plugins: {
        legend: {
          labels: {
            color: '#495057'
          }
        }
      }
    }
  }

  getDarkTheme() {
    return {
      plugins: {
        legend: {
          labels: {
            color: '#ebedef'
          }
        }
      }
    }
  }

}
