import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppComponent } from './app.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { EditProductComponent } from './edit-product/edit-product.component';

const routes: Routes = [
  {path:"home",component:AppComponent},
  {path:"about",component:AboutUsComponent},
  {path:"dashboard", component:DashboardComponent},
  {path:"product/edit/:id/:name", component:EditProductComponent},
  {path:'',redirectTo:"home", pathMatch:'full'},
  {path:'**',redirectTo:"home", pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
