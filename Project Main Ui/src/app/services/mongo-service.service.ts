import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../Models/OrderDetails';

@Injectable({
  providedIn: 'root'
})
export class MongoServiceService {

  baseUrl ="https://localhost:7048/"
  constructor(private httpclient:HttpClient) { }


  addOrder(order:Order){
   return this.httpclient.post<Order>(this.baseUrl+"gateway/addOrder",order)
  }
}
