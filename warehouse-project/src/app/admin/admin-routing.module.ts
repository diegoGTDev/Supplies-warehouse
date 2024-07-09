import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AuthGuard } from '../security/guards/auth.guard';

const routes : Routes = [
  { canMatch : [AuthGuard], path: '', component: AdminComponent, children: [
    { path: 'users', component: AdminComponent},
  ]}
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
