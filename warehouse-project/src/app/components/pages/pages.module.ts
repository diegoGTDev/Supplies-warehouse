import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ReusableModule } from '../reusable/reusable.module';
import { NotFoundComponent } from '../not-found/not-found.component';
import { RequirementRequestComponent } from './requirement/requirement-request/requirement-request.component';
import { RequirementAllComponent } from './requirement/requirement-all/requirement-all.component';
import { InventoryComponent } from './inventory/inventory.component';


@NgModule({
  declarations: [
    PagesComponent,
    NavigationComponent,
    NotFoundComponent,
    RequirementRequestComponent,
    RequirementAllComponent,
    InventoryComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    ReusableModule
  ]
})
export class PagesModule { }
