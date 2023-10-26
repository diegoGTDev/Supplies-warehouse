import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { LoginComponent } from './public/auth/login/containers/login/login.component';

import { NewRequiModalComponent } from './components/modals/new-requi-modal/new-requi-modal.component';
import { PublicModule } from './public/public.module';
import { PublicRoutingModule } from './public/public-routing.module';
import { ReusableModule } from './components/reusable/reusable.module';

@NgModule({
  declarations: [
    AppComponent,
    NewRequiModalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReusableModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
