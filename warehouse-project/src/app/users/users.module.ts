import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users.component';
import { UsersRoutingModule } from './users-routing.module';
import { ReusableModule } from '../reusable/reusable.module';
import { RequirementAllComponent } from './components/requirement/requirement-all/requirement-all.component';
import { RequirementRequestComponent } from './components/requirement/requirement-request/requirement-request.component';
import { UsersNavigationComponent } from './components/users-navigation/users-navigation.component';
import { InventoryComponent } from './components/inventory/new/inventory.component';
import { ContainerLayoutComponent } from "../public/components/container-layout/container-layout.component";
import { TitleContainerComponent } from '../public/components/title-container/title-container.component';
import { InventoryViewComponent } from './components/inventory/view/inventory-view.component';

@NgModule({
  declarations: [
    UsersComponent,
    RequirementAllComponent,
    RequirementRequestComponent,
    UsersNavigationComponent,
    InventoryComponent,
    InventoryViewComponent

  ],
  imports: [
    UsersRoutingModule,
    CommonModule,
    ReusableModule,
    ContainerLayoutComponent,
    TitleContainerComponent
]
})
export class UsersModule { }
