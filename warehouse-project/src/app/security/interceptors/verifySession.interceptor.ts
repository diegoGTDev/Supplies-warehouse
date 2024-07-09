import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';

@Injectable()
export class verifySessionInterceptor implements HttpInterceptor {
  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _snackbar: MatSnackBar
  ) {}
  private handleAuthError(error: HttpErrorResponse): Observable<any> {
    //handle your auth error or rethrow
    console.log("CAQUITA");
    console.log("The status is: ", error.status);

    if (error.status === 401 || error.status === 403) {
      console.log("Enter caquita");
      this._snackbar.open('Session expired', 'Close', {duration: 2000, panelClass: ['red-snackbar'], verticalPosition: 'top'})
      this._router.navigate(['/login']);
      this._authService.logout();
      return of(error.message);
    }
    return throwError(error);
  }
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    //Get user info
    if (!this._authService.isLoggin){
      return next.handle(request);
    }
    var user = this._authService.userInfo;
    // Clone the request to add the new header.
     const authRequest = request.clone({
      setHeaders:{
        Authorization: `Bearer ${user.token}`
      }
    })
     // catch the error, make specific functions for catching specific errors and you can chain through them with more catch operators
     return next.handle(authRequest).pipe(catchError(x=> this.handleAuthError(x))); //here use an arrow function, otherwise you may get "Cannot read property 'navigate' of undefined" on angular 4.4.2/net core 2/webpack 2.70
  }
}
