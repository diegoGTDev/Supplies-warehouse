import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth/auth.service';
import { iUser } from 'src/app/core/models/iUser';
import { Role } from 'src/app/core/models/Role';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {

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

  constructor(private breakpointObserver: BreakpointObserver, private _authService : AuthService) {
    this._authService.userData.subscribe(user => {
      this.userName = user.userName;
      this.userInfo = user;
    })
  }

  verifyDepartment(){
    var Roles = new Role();
    var departments = [Roles.ADMINISTRATOR, Roles.DISPATCHER, Roles.INVENTORY_MANAGER, Roles.MANAGER, Roles.SUPERVISOR, Roles.WAREHOUSE_SUPERVISOR];
    return departments.includes(this.userInfo.role.toUpperCase());
  }
  logout(){
    this._authService.logout();
  }
}
