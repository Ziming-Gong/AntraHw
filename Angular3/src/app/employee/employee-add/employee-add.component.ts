import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent {
  constructor(private service:EmployeeService, private router:Router){
    
  }
  // firstName:string = "";
  // lastName:string="";
  // email:string="";
  // resumeURL="";

  candidateModel={
    id: 0,
    firstName: "",
    lastName: "",
    email: "",
    resumeURL: ""
   }

   create(createForm:NgForm){
    this.service.CreateCandidate(this.candidateModel).subscribe(x =>{
      if(x == 1){
        console.log("create successfully")
      }else{
        console.log("Oops!")
      }
    })
   }
}
