import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorAddComponent } from './vendor-add/vendor-add.component';
import { VendorListComponent } from './vendor-list/vendor-list.component';

const routes: Routes = [
  {path:'add',component:VendorAddComponent},
  {path:'list', component:VendorListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
