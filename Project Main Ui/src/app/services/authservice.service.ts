import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import{JwtHelperService} from '@auth0/angular-jwt'
import { Observable } from 'rxjs';
import { User } from '../Models/user';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthserviceService {
  //base url link for the authentication process in backend
  url="https://localhost:7048/";

  //variables that are to be used
  private userPayload:any;
  userID:number=0; 
  
  constructor(private httpclient:HttpClient,private router:Router) { 
    this.userPayload = this.decodedToken();
  }
  

  //method used to post a login request to the backend
  public login(user:User){
    return this.httpclient.post<any>(this.url+"gateway/login",user)
  }

  //method used toe register a user
  public register(user:User):Observable<User[]>{
    return this.httpclient.post<User[]>(this.url+"gateway/addNewUser",user)
  }

  //method used to store the token after login
  storeToken(tokenValue:string){
    localStorage.setItem('token',tokenValue)
  }

  //method used to store the id after login
  storeId(id:number){
      localStorage.setItem("userid",id.toString())
  }

  // this method is used to get the id from the user any time, it is stored in the local storage
  getUserId(){
    var id = localStorage.getItem('userid')
    let numberId = Number(id);
    return numberId;
  }

  //this method is used to get the token from the local storage
  getToken(){
    return localStorage.getItem('token')
  }

  //this method is to check whether the user is logged in or not
  isLoggedIn():boolean{
    return !!localStorage.getItem('token');
  }


  // this method is used to signout the user
  signOut(){
    localStorage.clear();
    this.router.navigate(['login'])
  }

  //this method is usedd to decode the token
  decodedToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken();
    console.log(jwtHelper.decodeToken(<string>token))
    return jwtHelper.decodeToken(<string>token)
    
  }

  //method is used to get full name from token
  getFullNameFromToken(){
    if(this.userPayload){
      
      return this.userPayload["nameid"];
    }
  }

  //this method is used to get role from token
  getRoleFromToken(){
    if(this.userPayload){
      return this.userPayload["role"];
    }

  

  }
}
