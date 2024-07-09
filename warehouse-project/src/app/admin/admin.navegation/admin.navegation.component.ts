import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth/auth.service';
import { iUser } from 'src/app/core/models/iUser';

@Component({
    selector: 'app-admin-navegation',
    templateUrl: './admin.navegation.component.html',
    styleUrls: ['./admin.navegation.component.css'],
})
export class AdminNavegationComponent {
  userName : string = "user";
  userInfo : iUser = {
    userName : "",
    department : "",
    role : "",
    token : ""
  }
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
  .pipe(
    map(result => result.matches),
    shareReplay()
  );

  constructor(private breakpointObserver : BreakpointObserver, private _authService : AuthService){
    this._authService.userData.subscribe(user => {
      this.userName = user.userName;
      this.userInfo = user;
    })
  }
  verifyDepartment(){
    return true;
  }

  logout(){
    this._authService.logout();
  }
}
