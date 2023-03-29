import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../Models/OrderDetails';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  //base url
  baseUrl = "https://localhost:7048/"
  constructor(private httpclient: HttpClient) { }


  // this is the method to get all products from the backend
  getAllProducts(){
    return this.httpclient.get(this.baseUrl+"gateway/getAllProducts")
  }

  getProductById(productId:number){
    return this.httpclient.get(this.baseUrl+"gateway/getProductById/"+productId)
  }
  getProductByCategoryId(id:number){
    return this.httpclient.get(this.baseUrl+"gateway/getProductByCategory/"+id)
  }

  addProduct(product:Product){
    return this.httpclient.post(this.baseUrl+"gateway/addNewProduct", product)
  }

  deleteProduct(id:number){
    return this.httpclient.delete(this.baseUrl+"gateway/deleteProduct/"+id)
  }

  updateProduct(product:Product){
    return this.httpclient.put(this.baseUrl+"gateway/updateProduct",product)
  }


}
