import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorListComponent } from './vendor-list/vendor-list.component';
import { VendorAddComponent } from './vendor-add/vendor-add.component';


@NgModule({
  declarations: [
    VendorListComponent,
    VendorAddComponent
  ],
  imports: [
    CommonModule,
    VendorRoutingModule
  ]
})
export class VendorModule { }
