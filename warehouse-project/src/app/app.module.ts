import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LoginComponent } from './public/auth/login/containers/login/login.component';

import { NewRequiModalComponent } from './users/components/modals/new-requi-modal.component';
import { PublicModule } from './public/public.module';
import { PublicRoutingModule } from './public/public-routing.module';
import { ReusableModule } from './reusable/reusable.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './security/interceptors/jwt.interceptor';
import { InterceptorsProviders } from './security/interceptors/interceptors';
import { verifySessionInterceptor } from './security/interceptors/verifySession.interceptor';
import { Router } from '@angular/router';

@NgModule({
  declarations: [AppComponent, NewRequiModalComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReusableModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: verifySessionInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
