import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagesComponent } from './pages.component';
import { RequirementRequestComponent } from './requirement/requirement-request/requirement-request.component';
import { RequirementAllComponent } from './requirement/requirement-all/requirement-all.component';
import { InventoryComponent } from './inventory/inventory.component';

const routes: Routes = [
  {
    path: '', component: PagesComponent, children: [
      { path: 'requirement/request', component: RequirementRequestComponent },
      { path: 'requirement/all', component: RequirementAllComponent},
      { path: 'inventory/view', component: InventoryComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
