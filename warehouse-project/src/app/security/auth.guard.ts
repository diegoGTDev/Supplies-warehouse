import { ActivatedRoute, ActivatedRouteSnapshot, CanActivate, CanLoad, CanMatch, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanMatch{
  constructor(private _authService: AuthService, private _router: Router){

  }
  canMatch(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    var test;
    this._authService.userLoginOn.pipe(
      map(res =>{
        console.log("Res in guard was: ", res);
        test = res;
      })
    ).subscribe(test);



    console.log("Test in guard was: ", test);
    if(test){
      return true;
    }
    else{
      this._router.navigate(['/login']);
      return false;
    }
  }
}
