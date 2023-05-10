import { Component } from '@angular/core';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent {
  products=[
    {id:1,name: "chair",price:450},
    {id:2,name: "bed",price:100},
    {id:3,name: "desk",price:50}
  ]
}
