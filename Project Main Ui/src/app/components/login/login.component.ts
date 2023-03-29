import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { AuthserviceService } from 'src/app/services/authservice.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { MatSnackBar,MatSnackBarConfig } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {


  //variables to be declared
  loginform!:FormGroup

  user:User={
      Id:0,

       FirstName  :"",
       LastName  :"",

       Username  :"",
       Email  :"",
       Password  :"",
       Token :"",
       Role  :"",
       PhoneNumber:""
  }

  response={
    message:"",
    token:""
  }

  role:any="Admin"




  constructor(private fb:FormBuilder, private service:AuthserviceService, private router:Router,private userStore:UserStoreService,private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.loginform = this.fb.group({
      username:['',Validators.required],
      password:['',Validators.required]
    })
  }


  //this code is used for validations and login
  onLogin(){
    if(this.loginform.valid){
      //validation
      this.user.Username = this.loginform.value.username
      this.user.Password = this.loginform.value.password
      console.log(this.user)
      // send the object to database and get the response
      this.service.login(this.user).subscribe((resp)=>{
        console.log(resp)
        

      // used to store the id after login
      this.service.storeId(resp.userId)
        
        this.loginform.reset()
        // used to store the token after login
        this.service.storeToken(resp.token);

        //used to decode the token
        const tokenPayload = this.service.decodedToken()
        
        //storing the name and role in userstore for faster access
        this.userStore.setFullnameForStore(tokenPayload["nameid"])
        this.userStore.setRoleForStore(tokenPayload["role"])


        this.showSnackBar()
        
        

        
        
        // this code is to get the role very quickly 
        this.userStore.getRoleFromStore().subscribe(val=>{
          let roleFormToken = this.service.getRoleFromToken();
          console.log(roleFormToken)
          this.role = val || roleFormToken})
          console.log("you are :"+this.role)
          console.log(this.service.getUserId())

          
          
        //if the user is admin then direct him to admin page else direct him to home page
          if(this.role=="Admin"){
            console.log("role in if:"+this.role);
            this.router.navigate(['/dashboard'])
          }
          else{
            this.router.navigate(['/home'])
          }


          
        
        
        
        
        
        
        
      },(error:HttpErrorResponse)=>{
        console.log(error);
        this.showErrorSnackBar()

      }
      )

    }else{
      //throw an error using toaster and required field
      console.log("form is not valid")
      this.validateAllFormFields(this.loginform)
      console.log("form is invalid")
    }
  }


  // method used to validate 
  private validateAllFormFields(formgroup:FormGroup){
    Object.keys(formgroup.controls).forEach(field=>{
      const control = formgroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});
      }else if(control instanceof FormGroup){
        this.validateAllFormFields(control)
      }
    })
  }



  showSnackBar() {
    const config = new MatSnackBarConfig();
    config.duration = 5000; // 3 seconds
    config.panelClass = ['green-snackbar']; // add your custom class here
    this.snackBar.open('Login Successful', 'Close', config);
  }

  showErrorSnackBar() {
    const config = new MatSnackBarConfig();
    config.duration = 3000; // 3 seconds
    config.panelClass = ['green-snackbar']; // add your custom class here
    this.snackBar.open('Login Failed. Please enter a valid Email and password', 'Close', config);
  }
}
