import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private _authService : AuthService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log("Interceptando jwt");
    var user = this._authService.userInfo;
    console.log("user is ", user);
    if (user){
      //Clonar la request
      request = request.clone({
        setHeaders:{
          Authorization: `Bearer ${user.token}`
        }
      })
    }
    return next.handle(request);
  }
}
