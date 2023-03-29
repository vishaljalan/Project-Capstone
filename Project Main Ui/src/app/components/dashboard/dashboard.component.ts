import { HttpErrorResponse } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/Models/user';
import { ApiserviceService } from 'src/app/services/apiservice.service';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { ProductServiceService } from 'src/app/services/product-service.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  userList:any;

  public dataSource!: MatTableDataSource<any>;
  displayedColumns: string[]=["firstname","lastname", "username","email","role","phonenumber","Operations"]
  
 
  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!:MatSort;

  user:User={
    "Id":0,

    "FirstName"  :"string",
    "LastName"  :"string",

    "Username"  :"string",

    "Email"  :"string",
    "Password"  :"string",
    "Token"  :"string",
    "Role"  :"string",
    "PhoneNumber":"string"
  }

  tempuser:any={
    "id":0,

    "FirstName"  :"string",
    "LastName"  :"string",

    "Username"  :"string",

    "Email"  :"string",
    "Password"  :"string",
    "Token"  :"string",
    "Role"  :"string",
    "PhoneNumber":"string"
  }

  productsList:any


  constructor(private service:AuthserviceService, private apiservice:ApiserviceService, private product:ProductServiceService){
    
  }
  role:any
    ngOnInit(){
      this.getAllUsers()
      this.getAllProducts()
      
    }

    getAllUsers(){
      this.apiservice.getAllUsers().subscribe((resp)=>{
        this.userList = resp
        
        console.log(this.userList)
        this.dataSource = new MatTableDataSource(this.userList)
        this.dataSource.paginator = this.paginator
        this.dataSource.sort = this.sort
      })
    }

    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
  
      if (this.dataSource.paginator) {
        this.dataSource.paginator.firstPage();
      }
  
  
  }

  getUser(user:any){
    console.log(this.tempuser)
    this.tempuser = user
    console.log(this.tempuser)
    
  }

  deleteUser(user:any){
    console.log(user)
    this.apiservice.deleteUserById(user.id).subscribe((resp)=>{
      console.log(resp)
      this.getAllUsers()
    },(error:HttpErrorResponse)=>{
      console.log(error)
    })
  }


  addUser(){
    console.log(this.user)
    this.apiservice.addNewUser(this.user).subscribe((resp)=>{
      console.log(resp)
      this.getAllUsers()
      


    },(error:HttpErrorResponse)=>{
      console.log(error);})
  }


  updateUser(){
    console.log(this.tempuser.id)
    
    console.log(this.user)
    this.apiservice.updateUserById( this.tempuser.id, this.user).subscribe((resp)=>{
      console.log(resp)
      this.getAllUsers()

    },
    (error:HttpErrorResponse)=>{
      console.log(error);})
  }



  getAllProducts(){
    this.product.getAllProducts().subscribe((resp)=>{
      
      this.productsList = resp
      console.log(this.productsList)
    })
  }


}
