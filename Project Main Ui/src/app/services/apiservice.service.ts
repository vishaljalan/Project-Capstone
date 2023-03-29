import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  //base url
  url="https://localhost:7048/";

  constructor(private httpclient:HttpClient) { }

  //method is used to get all the users
  getAllUsers(){
    return this.httpclient.get<any>(this.url+"gateway/getAllUsers")
  }
  deleteUserById(userId:number){
    return this.httpclient.delete(this.url+"gateway/deleteUser/"+userId)
  }

  updateUserById(id:number,user:User){
    return this.httpclient.put(this.url+"gateway/updateUser/"+id,user)
  }

  addNewUser(user:User){
    return this.httpclient.post(this.url+"gateway/addNewUser",user)
  }
}
