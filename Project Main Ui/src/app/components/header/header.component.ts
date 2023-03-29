import { Component } from '@angular/core';
import { ApiserviceService } from 'src/app/services/apiservice.service';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  user:any=[]
  fullname:string="";
  role:string="";
  loginStatus:any;



  constructor(private service:AuthserviceService,private apiservice:ApiserviceService,private userStore:UserStoreService) { }


  ngOnInit(): void {
    
    this.loginStatus = this.service.isLoggedIn()

      this.userStore.getFullNameFromStore().subscribe(val=>{
        console.log(val)
        let fullnameFromToken = this.service.getFullNameFromToken();
        this.fullname = val || fullnameFromToken
      })

      this.userStore.getRoleFromStore().subscribe(val=>{
        let roleFormToken = this.service.getRoleFromToken();
        console.log(roleFormToken)
        this.role = val || roleFormToken      })


 
  }

  logout(){
    this.loginStatus = false;
    this.service.signOut()

    
  }




}
