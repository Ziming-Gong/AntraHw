import { Component } from '@angular/core';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})



export class ContactComponent {
  showContent:boolean=true;

  // click me method
  logMessageOnConsole(){
    console.log("this is click me")
  }

  toggle:boolean=true;

  toggleParagraph(){
    this.toggle = !this.toggle;
  }

  countries=["USA","UK","India","China","Germany","France"]


  customer =[
    {id:1, name:"Daniel", age:30, city:"Seattle"},
    {id:2, name:"Kevin", age:24, city:"Chicago"},
    {id:3, name:"Rhea", age:45, city:"Sterling"},
    {id:4, name:"Smith", age:33, city:"Aurora"},
  ]


}
