import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ReusableModule } from '../reusable/reusable.module';
import { NotFoundComponent } from '../not-found/not-found.component';
import { RequirementRequestComponent } from './requirement-request/requirement-request.component';


@NgModule({
  declarations: [
    PagesComponent,
    NavigationComponent,
    NotFoundComponent,
    RequirementRequestComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    ReusableModule
  ]
})
export class PagesModule { }
