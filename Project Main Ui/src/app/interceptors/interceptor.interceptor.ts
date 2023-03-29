import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { AuthserviceService } from '../services/authservice.service';
import { Router } from '@angular/router';

@Injectable()
export class InterceptorInterceptor implements HttpInterceptor {

  constructor(private service:AuthserviceService, private router:Router) {}


  //interceptor is used tie intercept the request and add a header which is the token
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const myToken = this.service.getToken();

    if(myToken){

      request = request.clone({
        setHeaders:{Authorization:`Bearer ${myToken}`}
      })

    }

    


    return next.handle(request).pipe(

      catchError((err:any)=>{
        if(err instanceof HttpErrorResponse){
          if(err.status===401){
            this.router.navigate(['login'])
          }
        }
        return throwError(()=>new Error("Some Error Occured"))
      })
    );
  }
}
