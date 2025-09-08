import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { StoreModule } from '@ngrx/store';
import { counterReducer } from './counter/counter.reducer';
import { usersReducer } from './users/users.reducer';
import { CreateUser } from './create-user/create-user';
import { ViewUser } from './view-user/view-user';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    App,
    CreateUser,
    ViewUser
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    StoreModule.forRoot({ 
      counter: counterReducer,
      users: usersReducer,
     })
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
