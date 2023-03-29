import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductServiceService } from 'src/app/services/product-service.service';

@Component({
  selector: 'app-products-by-category',
  templateUrl: './products-by-category.component.html',
  styleUrls: ['./products-by-category.component.css']
})
export class ProductsByCategoryComponent {
  id!: number;
  productList:any
  constructor(private route: ActivatedRoute, private service:ProductServiceService) {}
  
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      // do something with the ID

      
    });

    this.getProductsByCategoryId()
    console.log(this.id)
  }

  getProductsByCategoryId(){
      this.service.getProductByCategoryId(this.id).subscribe((resp)=>{
        this.productList = resp;
      })
  }
}
