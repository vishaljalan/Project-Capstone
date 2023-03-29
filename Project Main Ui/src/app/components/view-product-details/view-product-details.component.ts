import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cart } from 'src/app/Models/Cart';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductServiceService } from 'src/app/services/product-service.service';

@Component({
  selector: 'app-view-product-details',
  templateUrl: './view-product-details.component.html',
  styleUrls: ['./view-product-details.component.css']
})
export class ViewProductDetailsComponent {

  productId!: number | null;
  product:any
  loginstatus:any
  addCart:Cart={
    userId: 0,
    productId :0,
    productPrice:0
  }

  productsList:any

  

  smallImages: string[] = [
    'https://source.unsplash.com/random/500x500?Laptop',
    'https://source.unsplash.com/random/500x500?Iphone',
    'https://source.unsplash.com/random/500x500?MacBook'
  ];
  mainImage: string = 'https://source.unsplash.com/random/500x500?Laptop';
  



  constructor(private route: ActivatedRoute, private productservice:ProductServiceService, private auth:AuthserviceService, private service:AuthserviceService, private cartService:CartService, private router:Router) { }

  ngOnInit() {
    this.loginstatus = this.auth.isLoggedIn()
    if (this.route) {
      const id = this.route.snapshot.paramMap.get('id');
      this.productId = id ? +id : null;
      console.log(this.productId)
      this.getProductById()
    }
  }

  getProductById(){
    if(this.productId!=null){
      this.productservice.getProductById(this.productId).subscribe((resp)=>{
        console.log(resp)
        this.product = resp

      })
    }
    
  }


  //add to cart 
  addToCart(productId:number, price:number){
    console.log(productId)
    console.log(price)
    this.addCart.productId = productId
    this.addCart.productPrice = price
    this.addCart.userId = this.service.getUserId()

    console.log(this.addCart)
    this.cartService.addCart(this.addCart).subscribe((resp)=>{
      console.log(resp);
    })

    this.router.navigate(['/viewCart'])
    
  }

  onSmallImageClick(imageSrc: string) {
    this.mainImage = imageSrc;
  }

}
