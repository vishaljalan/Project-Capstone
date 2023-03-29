import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthserviceService } from '../services/authservice.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth:AuthserviceService,private router:Router){}

  //auth guard is used to guard the components if the user is not logged in
  canActivate():boolean{
    if(this.auth.isLoggedIn()){

      return true;
    }
    else{
      this.router.navigate(['login'])
      return false;
    }
  }
  
}
