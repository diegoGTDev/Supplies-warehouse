import { ActivatedRoute, ActivatedRouteSnapshot, CanActivate, CanLoad, CanMatch, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanMatch{
  constructor(private _authService: AuthService, private _router: Router, private _snackBar : MatSnackBar){

  }
  canMatch(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    var isLogged;
    if (this._authService.isLoggin === false){
      console.log("You-are-logged-in");
      this._snackBar.open('Session expired', 'Close', {duration: 2000, panelClass: ['red-snackbar'], verticalPosition: 'top'})
      this._router.navigate(['/login']);
      return false;
    }
    this._authService.userLoginOn.pipe(
      map(res =>{
        console.log("Res in guard was: ", res);
        isLogged = res;
      })
    ).subscribe(isLogged);



    console.log("Test in guard was: ", isLogged);
    if(isLogged){
      return true;
    }
    else{
      this._router.navigate(['/login']);
      return false;
    }
  }
}
