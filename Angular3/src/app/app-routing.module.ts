import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { authGuard } from './shared/guard/auth.guard';
import { AccessForbiddenComponent } from './access-forbidden/access-forbidden.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:'app',component:LayoutComponent, canActivate:[authGuard], children:[
      {path:'employee',loadChildren:() => import('./employee/employee.module').then(m => m.EmployeeModule)},
      {path:'vendor', loadChildren: () => import('./vendor/vendor.module').then(m => m.VendorModule)}
    ]},
    {path:"", redirectTo:"login", pathMatch:'full'},
    // {path:"**", component:AccessForbiddenComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
