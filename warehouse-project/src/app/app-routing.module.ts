import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './public/auth/login/containers/login/login.component';
import { NotFoundComponent } from './core/shared/components/not-found/not-found.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {path:'', component:AppComponent,children:[
    {path:'', loadChildren: () => import('./public/public.module').then(x => x.PublicModule)}
  ]},
  //{ path: 'login', component: LoginComponent },
  { path: 'pages', loadChildren: () => import('./components/pages/pages.module').then(x => x.PagesModule) },
  {path:'**',component:NotFoundComponent,pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
