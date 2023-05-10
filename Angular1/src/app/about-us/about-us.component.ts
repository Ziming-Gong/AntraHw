import { Component } from '@angular/core';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent {
//  studentName:String = "Robb";
student={
  id: 2,
  name:"Daniel",
  age:31,
  city:"seattle"

}
 products = [
  {id:1, name: "chair", price:450},
  {id:2, name: "desk", price:90},
  {id:3, name: "table", price:10},
  {id:4, name: "TV", price:300}
 ]
}
