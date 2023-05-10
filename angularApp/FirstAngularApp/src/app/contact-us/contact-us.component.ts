import { Component } from '@angular/core';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent {
  showContent:boolean=false;
  logMessageOnConsole(){
    console.log("button is click");
  }
  toggle:boolean=true;
  toggleParagraph(){
    this.toggle = !this.toggle;
  }

  countries = ["China","USA","UK","India","Germany","France"]


  customers =[
    {id:1, name:"Daniel", age:31, city:"Chicago"},
    {id:2, name:"Smith", age:40, city:"Tempa"},
    {id:3, name:"Robb", age:31, city:"Beijing"},
    {id:4, name:"Alex", age:31, city:"LA"},

  ]


}
