import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Login } from './login/login';
import { Profile } from "./profile/profile";
import { ReactiveFormsModule } from '@angular/forms';
import { ReactiveformComponent } from './reactive/reactive';

@NgModule({
  declarations: [
    App,
    Login,
    ReactiveformComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    Profile,
    ReactiveFormsModule
],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
