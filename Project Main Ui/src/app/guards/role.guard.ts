import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthserviceService } from '../services/authservice.service';
import { UserStoreService } from '../services/user-store.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  //variables to be used
  role:any


  constructor(private auth:AuthserviceService,private router:Router,private userStore:UserStoreService){}
  
  // role guard is used to guard role specific components
  canActivate():boolean{
    this.userStore.getRoleFromStore().subscribe(val=>{
      let roleFormToken = this.auth.getRoleFromToken();
      console.log(roleFormToken)
      this.role = val || roleFormToken})
      

    if(this.auth.isLoggedIn()&&this.role=="Admin"){

      return true;
    }
    else{

      //redirect to bad request page in future
      this.router.navigate(['home'])
      return false;
    }
  }


  
  
}
