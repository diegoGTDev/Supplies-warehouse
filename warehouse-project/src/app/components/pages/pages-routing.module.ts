import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagesComponent } from './pages.component';
import { RequirementRequestComponent } from './requirement/requirement-request/requirement-request.component';
import { RequirementAllComponent } from './requirement/requirement-all/requirement-all.component';
import { InventoryComponent } from './inventory/inventory.component';
import { AuthGuard } from 'src/app/security/guards/auth.guard';
import { Role } from 'src/app/core/models/Role';
import { hasRoleGuard } from 'src/app/security/guards/hasRole.guard';
const role = new Role();
const allowedRoles =
  [role.ADMINISTRATOR, role.DISPATCHER, role.INVENTORY_MANAGER,role.MANAGER, role.WAREHOUSE_SUPERVISOR, role.SUPERVISOR];
const routes: Routes = [
  {
    canMatch: [AuthGuard],
    path: '', component: PagesComponent, children: [
      { path: 'requirement/request', component: RequirementRequestComponent},
      { path: 'requirement/all', component: RequirementAllComponent, data: {allowedRoles},
    canMatch: [hasRoleGuard]
    },
      { path: 'inventory/view', component: InventoryComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
