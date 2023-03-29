import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { AuthserviceService } from 'src/app/services/authservice.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

     //variables and declaration
  signupform!:FormGroup
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


  constructor(private service:AuthserviceService,private router:Router,private fb:FormBuilder,private snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this.signupform = this.fb.group({
      username:['',Validators.required],
      password:['',Validators.required],
      firstname:['',Validators.required],
      lastname:['',Validators.required],
      Password:['',Validators.required],
      PhoneNumber:['',Validators.required]

    })
  }


  //  when the user clicks on submit this method is used and it registers the user
  public onSubmit(){
   
      //validation
      
      console.log(this.user)
      this.service.register(this.user).subscribe((resp)=>{
      console.log(resp)
      this.router.navigate(['login']);

      this.showSnackBar()
    })
    }
    

  




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
    this.snackBar.open('Registration Successful', 'Close', config);
  }
}
