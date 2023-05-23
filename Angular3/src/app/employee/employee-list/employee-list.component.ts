import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
  constructor(private employeeService:EmployeeService,private router:Router){
   this.employeeService.getAllCandidate().subscribe(employees =>{
    console.log(employees);
    this.employeesList = employees
   }) 
  }

  employeesList:any;

  delete(event:any){
    this.employeeService.deleteCandidateById(event.target.value).subscribe(x =>{
      console.log("number of " + x + " record has been delete");
      this.router.navigateByUrl('/app/employee/list');
    })
  }
}
