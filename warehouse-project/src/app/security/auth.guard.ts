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
    return this._authService.currentUserLoginOn.asObservable().pipe(
      map((isLoggedIn => isLoggedIn || this._router.createUrlTree(['/login'])))
    ) as Observable<boolean | UrlTree>;
  }
}
