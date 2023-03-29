import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Carts } from 'src/app/Models/CartItems';
import { Order } from 'src/app/Models/OrderDetails';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { CartService } from 'src/app/services/cart.service';
import { MongoServiceService } from 'src/app/services/mongo-service.service';

@Component({
  selector: 'app-checkout-page',
  templateUrl: './checkout-page.component.html',
  styleUrls: ['./checkout-page.component.css']
})
export class CheckoutPageComponent {

  totalBill!:any
  usercart!:Carts
  userId!:number
  product!:any[]
  counts: any = {};
  uniqueProduct!:any[];
  id:string=""
  
  order: Order = {
      id: '',
      userId: 456,
      name: 'John Doe',
      email: 'john.doe@example.com',
      address:"address",
      total:1010,
      products: []
    };

    orderResp: Order = {
      id: '',
      userId: 456,
      name: 'John Doe',
      email: 'john.doe@example.com',
      address:"address",
      total:1010,
      products: []
    };
  

 
  

  constructor(private route: ActivatedRoute, private auth:AuthserviceService, private cart: CartService, private mongo:MongoServiceService,private router: Router) {}
componentName="checkout";
  ngOnInit() {
    this.getCartItems()
   
    this.route.queryParams.subscribe(params => {
      this.totalBill = params['param1'];
      this.userId = params['param2'];
    
 

    console.log(this.product)
       
    });

    
   

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

  
placeOrder(){
  this.uniqueProduct = this.getUniqueProducts()
  console.log(this.uniqueProduct)
  for(let i=0; i<this.uniqueProduct.length;i++){
    
    
    this.order.products.push(this.uniqueProduct[i])

  }
  this.order.userId = this.auth.getUserId()
  this.order.total = this.usercart.totalPrice

 console.log(this.order)

  this.mongo.addOrder(this.order).subscribe((resp)=>{
    console.log(resp)
    this.orderResp = resp
    
    
   
    
    console.log(this.orderResp)

    this.clearCart()


    
       
      this.router.navigate(['/reciept'], { queryParams: {  order1: JSON.stringify(this.orderResp) } });
    
    


  });
 

  
    
}


clearCart(){
  this.cart.clearCart(this.auth.getUserId()).subscribe((resp)=>{
    console.log(resp)
  })
}



}
