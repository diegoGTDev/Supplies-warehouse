import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { LoginComponent } from './components/login/login.component';
import { ReusableModule } from './components/reusable/reusable.module';
import { NewRequiModalComponent } from './components/modals/new-requi-modal/new-requi-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NewRequiModalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReusableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
