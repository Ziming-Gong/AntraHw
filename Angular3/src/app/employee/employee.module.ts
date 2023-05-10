import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeAddComponent } from './employee-add/employee-add.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeService } from '../shared/services/employee.service';



@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeAddComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule
  ],
  providers:[EmployeeService]
})
export class EmployeeModule { }
