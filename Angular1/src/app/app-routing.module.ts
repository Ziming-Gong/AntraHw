import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './contact/contact.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  {path:"home", component:AppComponent},
  {path:"contact", component:ContactComponent},
  {path:"about", component:AboutUsComponent},
  {path:"dashboard", component:DashboardComponent},
  {path:"product/edit/:id/:name", component:EditProductComponent},
  {path:"", redirectTo:"home", pathMatch:'full'},
  {path:"**", component:PageNotFoundComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
