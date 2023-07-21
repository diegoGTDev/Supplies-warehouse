import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagesComponent } from './pages.component';
import { RequirementRequestComponent } from './requirement-request/requirement-request.component';

const routes: Routes = [
  {
    path: '', component: PagesComponent, children: [
      { path: 'requirement', component: RequirementRequestComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
