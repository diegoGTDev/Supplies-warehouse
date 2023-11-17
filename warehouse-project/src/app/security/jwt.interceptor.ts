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

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var user : any;
    this._authService.userData.subscribe(
      {
        next: (data) => {
          user = data;
        }
      }
    );

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
