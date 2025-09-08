import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { CourseList } from './components/course-list/course-list';
import { CourseDetail } from './components/course-detail/course-detail';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    App,
    CourseList,
    CourseDetail
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection()
  ],
  bootstrap: [App]
})
export class AppModule { }
