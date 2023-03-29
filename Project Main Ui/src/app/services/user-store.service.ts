import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
  //the methods written down are used to get the role and name quickly
  private fullName$ = new BehaviorSubject<string>("");
  private role$ = new BehaviorSubject<string>("");
  constructor() { }

  public getRoleFromStore(){
    return this.role$.asObservable();
  }

  public setRoleForStore(role:string){
    this.role$.next(role)
  }

  public getFullNameFromStore(){
   return this.fullName$.asObservable();
  }

  public setFullnameForStore(fullname:string){
    this.fullName$.next(fullname)
  }
}
