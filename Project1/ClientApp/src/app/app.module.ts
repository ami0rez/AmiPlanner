import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {DropdownModule} from 'primeng/dropdown';
import {TooltipModule} from 'primeng/tooltip';
import {InputNumberModule} from 'primeng/inputnumber';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {InputTextModule} from 'primeng/inputtext';
import {SplitterModule} from 'primeng/splitter';
import {ChartModule} from 'primeng/chart';
import {ScrollPanelModule} from 'primeng/scrollpanel';
import {EditorModule} from 'primeng/editor';
import { QuillModule } from 'ngx-quill'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './common/common.module';
import { AppConfigService } from './common/services/app-config-service';
import { GoalEditorComponent } from './goal/componenets/goal-editor/goal-editor.component';
import { GoalHeaderComponent } from './goal/componenets/goal-header/goal-header.component';
import { ProjectEditorComponent } from './project/components/project-editor/project-editor.component';
import { ProjectListComponent } from './project/components/project-list/project-list.component';
import { ProjectListHeaderComponent } from './project/components/project-list-header/project-list-header.component';
import { ProjectReaderComponent } from './project/components/project-reader/project-reader.component';
import { ProjectTaskHeaderComponent } from './project/components/project-task-header/project-task-header.component';
import { ProjectTaskItemComponent } from './project/components/project-task-item/project-task-item.component';
import { ProjectTaskDescriptionComponent } from './project/components/project-task-description/project-task-description.component';
import { FormsModule } from '@angular/forms';
import { DailyTasksComponent } from './daily-tasks/components/daily-tasks/daily-tasks.component';
import { DailyTasksItemComponent } from './daily-tasks/components/daily-tasks-item/daily-tasks-item.component';
import { DailyTasksFilterComponent } from './daily-tasks/components/daily-tasks-filter/daily-tasks-filter.component';
import { DailyTasksStatisticsComponent } from './daily-tasks/components/daily-tasks-statistics/daily-tasks-statistics.component';
import { CommonModule } from '@angular/common';
import { TriStateCheckboxModule } from 'primeng/tristatecheckbox';
import { ReactiveFormsModule } from '@angular/forms';
import { ServiceWorkerModule } from '@angular/service-worker';
import { MessagesModule } from 'primeng/messages';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { PaginatorModule } from 'primeng/paginator';
import { AvatarModule } from 'primeng/avatar';
import { MultiSelectModule } from 'primeng/multiselect';
import { TreeModule } from 'primeng/tree';
import { InvolysLibraryModule } from 'involys-library';
import { environment } from '../environments/environment';
import { CustomHttpInterceptor } from 'src/common/services/custom-http-interceptor.service';


@NgModule({
  declarations: [
    AppComponent,
    GoalEditorComponent,
    GoalHeaderComponent,
    ProjectEditorComponent,
    ProjectListComponent,
    ProjectListHeaderComponent,
    ProjectReaderComponent,
    ProjectTaskHeaderComponent,
    ProjectTaskItemComponent,
    ProjectTaskDescriptionComponent,
    DailyTasksComponent,
    DailyTasksItemComponent,
    DailyTasksFilterComponent,
    DailyTasksStatisticsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    CommonModule,
    AppRoutingModule,
    SharedModule,
    DropdownModule,
    HttpClientModule,
    TooltipModule,
    InputNumberModule,
    InputTextareaModule,
    InputTextModule,
    BrowserAnimationsModule,
    SplitterModule,
    ChartModule,
    ScrollPanelModule,
    EditorModule,
    TriStateCheckboxModule,
    MessagesModule,
    InvolysLibraryModule,
    NgbModule,
    PaginatorModule,
    ToastModule,
    ConfirmDialogModule,
    LoadingBarHttpClientModule,
    ReactiveFormsModule,
    AvatarModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    MultiSelectModule,
    TreeModule,
    QuillModule
  ],
  providers: [
    MessageService,
    ConfirmationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomHttpInterceptor,
      multi: true,
    },
    {
    provide: APP_INITIALIZER,
    multi: true,
    deps: [AppConfigService],
    useFactory: (appConfigService: AppConfigService) => {
      return () => {
        return appConfigService.loadAppConfig();
      };
    },
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
