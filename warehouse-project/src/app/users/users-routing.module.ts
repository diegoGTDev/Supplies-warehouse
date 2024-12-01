import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users.component';
import { AuthGuard } from '../security/guards/auth.guard';
import { Role } from '../core/models/Role';
import { hasRoleGuard } from '../security/guards/hasRole.guard';
import { RequirementRequestComponent } from './components/requirement/requirement-request/requirement-request.component';
import { RequirementAllComponent } from './components/requirement/requirement-all/requirement-all.component';
import { InventoryComponent } from './components/inventory/new/inventory.component';
import { InventoryViewComponent } from './components/inventory/view/inventory-view.component';

const role = new Role();
const allowedRoles =
  [role.ADMINISTRATOR, role.DISPATCHER, role.INVENTORY_MANAGER,role.MANAGER, role.WAREHOUSE_SUPERVISOR, role.SUPERVISOR];
const routes: Routes = [
  {
    canMatch: [AuthGuard],
    path: '', component: UsersComponent, children: [
      { path: 'requirement/request', component: RequirementRequestComponent},
      { path: 'requirement/all', component: RequirementAllComponent, data: {allowedRoles},
    canMatch: [hasRoleGuard]
    },
      { path: 'inventory/new', component: InventoryComponent},
      { path: 'inventory/view', component: InventoryViewComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
