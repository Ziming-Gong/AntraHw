import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {

  product={
    id:0,
    name:""
  }


  constructor(private route:ActivatedRoute){
    route.params.subscribe(data => {
      console.log(data);
      console.log(data["id"])
      console.log(data["name"])
      this.product.id = data["id"];
      this.product.name = data["name"];
    });
    
  }

}
