import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
  constructor(private employeeService:EmployeeService){
   this.employeeService.getAll().subscribe(employees =>{
    console.log(employees);
    this.employeesList = employees
   }) 
  }

  employeesList:any;
}
