import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from './admin-routing.module';
import { ReusableModule } from '../reusable/reusable.module';
import { AdminNavegationComponent } from './admin.navegation/admin.navegation.component';

@NgModule({
  declarations: [
    AdminComponent,
    AdminNavegationComponent
  ],
  imports: [
    AdminRoutingModule,
    CommonModule,
    ReusableModule
  ]
})
export class AdminModule { }
