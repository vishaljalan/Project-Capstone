import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cart } from 'src/app/Models/Cart';
import { ApiserviceService } from 'src/app/services/apiservice.service';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductServiceService } from 'src/app/services/product-service.service';
import { FooterComponent } from '../footer/footer.component';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent {

  productId!: number | null;
  product:any
  loginstatus:any
  addCart:Cart={
    userId: 0,
    productId :0,
    productPrice:0
  }

  smallImages: string[] = [
    'https://images.unsplash.com/photo-1600185365926-3a2ce3cdb9eb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1925&q=80',
    'https://images.unsplash.com/photo-1575537302964-96cd47c06b1b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',
    'https://images.unsplash.com/photo-1600185365483-26d7a4cc7519?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1925&q=80'
  ];
  mainImage: string = 'https://images.unsplash.com/photo-1600185365926-3a2ce3cdb9eb?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1925&q=80';
  



  constructor(private route: ActivatedRoute, private productservice:ProductServiceService, private auth:AuthserviceService, private service:AuthserviceService, private cartService:CartService, private router:Router) { }

  ngOnInit() {


    // this code is to reload the page 
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';

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

    this.router.navigate(['/cart'])
    
  }

  onSmallImageClick(imageSrc: string) {
    this.mainImage = imageSrc;
  }


}