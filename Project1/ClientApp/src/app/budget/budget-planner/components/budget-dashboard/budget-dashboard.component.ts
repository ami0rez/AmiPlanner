import { Component, Input, OnInit } from '@angular/core';
import { BudgetPage } from '../../models/budget-page';

@Component({
  selector: 'app-budget-dashboard',
  templateUrl: './budget-dashboard.component.html',
  styleUrls: ['./budget-dashboard.component.css']
})
export class BudgetDashboardComponent implements OnInit {

  @Input()
  pageObject: BudgetPage;
  basicData: any;
  horizontalOptions: any;
  data: any;
  chartOptions: any;

  constructor() { }

  ngOnInit(): void {
    this.data = {
      labels: ['Needs', 'Wants', 'Savings'],
      datasets: [
          {
              data: [300, 50, 100],
              backgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ],
              hoverBackgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ]
          }
      ]
  };
    this.basicData = {
      labels: ['Needs', 'Wants', 'Savings'],
      datasets: [
        {
          label: 'Estimated',
          backgroundColor: '#42A5F5',
          data: [65, 59, 80]
        },
        {
          label: 'Spent',
          backgroundColor: '#FFA726',
          data: [28, 48, 40]
        }
      ]
    };
    this.horizontalOptions = {
      indexAxis: 'y',
      plugins: {
        legend: {
          labels: {
            color: '#00000099'
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: '#00000099'
          },
          grid: {
            color: 'rgba(255,255,255,0.2)'
          }
        },
        y: {
          ticks: {
            color: '#00000099'
          },
          grid: {
            color: 'rgba(255,255,255,0.2)'
          }
        }
      }
    };
  }

}
