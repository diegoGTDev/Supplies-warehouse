import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private _authService : AuthService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var user = this._authService.test;


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
