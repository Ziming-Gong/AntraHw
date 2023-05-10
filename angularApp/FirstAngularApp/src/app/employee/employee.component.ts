import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
expForm = new FormGroup({
  fullName: new FormControl(),
  city: new FormControl(),
  age: new FormControl
});
}
