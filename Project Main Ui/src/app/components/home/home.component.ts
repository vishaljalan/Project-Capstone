import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/Models/Cart';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductServiceService } from 'src/app/services/product-service.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  //variables to be declared here
  loginStatus:any
  role:any
  fullname:any
  productsList:any
  addCart:Cart={
    userId: 0,
    productId :0,
    productPrice:0
  }





  constructor(private router:Router,private service:AuthserviceService, private userStore:UserStoreService, private userService:ProductServiceService, private cartService:CartService){
    
  }



  ngOnInit(){
    this.userLoggedIn();
    this.getAllProducts();

    // to get the name
    this.userStore.getFullNameFromStore().subscribe(val=>{
      console.log(val)
      let fullnameFromToken = this.service.getFullNameFromToken();
      this.fullname = val || fullnameFromToken
    })
    
    //to get the role
    this.userStore.getRoleFromStore().subscribe(val=>{
      let roleFormToken = this.service.getRoleFromToken();
      console.log(roleFormToken)
      this.role = val || roleFormToken      })

  }

  
  navigateLogin(){
    this.router.navigate(['/login'])
  }

  navigateSignup(){
    this.router.navigate(['/signup'])
  }

  //to check user logged in status
  userLoggedIn(){
    this.loginStatus =  this.service.isLoggedIn();
  }


  //logout
  logout(){
    
    this.service.signOut()

    
  }


  // to get all products
  getAllProducts(){
    this.userService.getAllProducts().subscribe((resp)=>{
      console.log(resp);
      this.productsList = resp
    })
    
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
  }

  navigateToCategory(id:number){
    console.log(id)
    this.router.navigate(['/category',id])
  }


}
