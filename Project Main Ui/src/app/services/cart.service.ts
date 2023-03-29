import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cart } from '../Models/Cart';
import { Carts } from '../Models/CartItems';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartbaseUrl ="https://localhost:7048/" 
  constructor(private httpclient:HttpClient) { }

  //this is the method to add to card which is called from the backend
  addCart(addCart:Cart){
    return this.httpclient.post(this.cartbaseUrl+"gateway/Cart/addToCart",addCart);
  }
  getCartItems(userId:number){
    return this.httpclient.get<Carts>(this.cartbaseUrl+"gateway/Cart/getCart/"+userId)
  }

  deleteCartItems(cartItemId:number){
    return this.httpclient.delete(this.cartbaseUrl+"gateway/Cart/deleteCartItem/"+cartItemId)
  }
  clearCart(id:number){
    return this.httpclient.delete(this.cartbaseUrl+"gateway/Cart/clearCart/"+id)
  }
}
