import { Component } from '@angular/core';
import { Carts } from 'src/app/Models/CartItems';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { CartService } from 'src/app/services/cart.service';
import { CommonModule } from '@angular/common';

//import{product} from 'src/app/Models/Products';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {

  usercart!:Carts
  userId!:number
  product!:any[]

  constructor(private cart:CartService, private auth:AuthserviceService){}

  ngOnInit(){
      this.getCartItems()

  }

  
  getCartItems(){
    this.userId = this.auth.getUserId()
    
    this.cart.getCartItems(this.userId).subscribe((resp)=>{
      console.log("response is="+resp)
      this.usercart = resp
      
      this.product = this.usercart.cartItems.map((item=>item.products))

      console.log(this.usercart)
      console.log(this.product)

    })
  }


}
