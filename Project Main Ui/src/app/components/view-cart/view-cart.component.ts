import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Carts } from 'src/app/Models/CartItems';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-view-cart',
  templateUrl: './view-cart.component.html',
  styleUrls: ['./view-cart.component.css']
})
export class ViewCartComponent {
  usercart!:Carts
  userId!:number
  product!:any[]
  counts: any = {};
  uniqueProduct:any;
  

  cartItemId:number=0;
  @Output() sendProductEvent = new EventEmitter<any>();
  

  constructor(private cart:CartService, private auth:AuthserviceService, private router:Router){}

  ngOnInit(): void {
      // this.getCartItems()
      this.userId = this.auth.getUserId()
    
      this.cart.getCartItems(this.userId).subscribe((resp)=>{
        console.log("response is="+resp)
        this.usercart = resp
        
        this.product = this.usercart.cartItems.map((item=>item.products))
      })

    }

  
  getCartItems(){
    this.userId = this.auth.getUserId()
    
    this.cart.getCartItems(this.userId).subscribe((resp)=>{
      console.log("response is="+resp)
      this.usercart = resp
      
      this.product = this.usercart.cartItems.map((item=>item.products))
    }) }





  getUniqueProducts(): any[] {
    let uniqueProducts: any[] = [];
    this.usercart.cartItems.forEach((item) => {
      let index = uniqueProducts.findIndex((p) => p.productId === item.products.productId);
      if (index === -1) {
        uniqueProducts.push(item.products);
      }
    });
    
    return uniqueProducts;
  }

  getQuantity(product: any): number {
    let count = 0;
    this.usercart.cartItems.forEach((item) => {
      if (item.products.productId === product.productId) {
        count += item.quantity;
      }
    });
    return count;
  }


  

  sendData(products:any,myusercart:any) {
     const totalBill = myusercart
     const userId = this.userId
     this.sendProductEvent.emit(this.uniqueProduct);
     
    
     
    this.router.navigate(['/checkout'], { queryParams: { param1: totalBill, param2: userId} });
  }



  // getUniqueProducts() {
  //   const uniqueProducts = [];
  //   const seenProductIds = new Set();
  
  //   for (const item of this.usercart.cartItems) {
  //     const productId = item.productId;
  //     if (!seenProductIds.has(productId)) {
  //       seenProductIds.add(productId);
  //       uniqueProducts.push(item.products);
  //     }
  //   }
  
  //   return uniqueProducts;
  // }
  
  // getProductQuantity(productId: number) {
  //   let count = 0;
  
  //   for (const item of this.usercart.cartItems) {
  //     if (item.productId === productId) {
  //       count += item.quantity;
  //     }
  //   }
  
  //   return count;
  // }



  getCartItemIdFromProductId(productId:number){
    for (const cartItem of this.usercart.cartItems) {
      if (cartItem.productId === productId && cartItem.cartId === this.usercart.cartId) {
        this.cartItemId = cartItem.cartItemId;
        break; // exit the loop since we found the cartItemId
      }
    }
  }

  deleteItem(product:number){
    this.getCartItemIdFromProductId(product)
    console.log(this.cartItemId)

    this.cart.deleteCartItems(this.cartItemId).subscribe((resp)=>{
      console.log(resp)
    })
    window.location.reload();


  }


  

  
}
