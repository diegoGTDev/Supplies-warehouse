import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReusableModule } from '../reusable/reusable.module';
import { PublicRoutingModule } from './public-routing.module';
import { PublicComponent } from './public.component';
import { LoginComponent } from './auth/login/containers/login/login.component';


@NgModule({
  declarations: [
    PublicComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    ReusableModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
