import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {
  
  constructor(private route:ActivatedRoute){
    route.params.subscribe(d=>{
      console.log(d);
    })
  }

  


}
