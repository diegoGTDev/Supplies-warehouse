import type { CanMatchFn } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';
export const hasRoleGuard: CanMatchFn = (route, segments) => {
  const allowedRoles = route.data?.['allowedRoles'];
  var authService = inject(AuthService)
  console.log(allowedRoles.includes("administrator".toUpperCase()));
  return authService.userData.pipe(
    map((user) => user && allowedRoles.includes(user.role.toString().toUpperCase())),
    );
};
