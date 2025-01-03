import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
// import { UsuarioServicioService } from '../../services/usuario-servicio.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/services/auth/auth.service';
import { iUserLogin } from 'src/app/core/models/iUserLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formLogin: FormGroup;
  hidePassword: boolean = true;
  loading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private _snackBar: MatSnackBar,
    private _authService: AuthService
  ) {
    this.formLogin = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
    this._authService.user.subscribe((e) => {
      if (e) {
        this.router.navigate(['/users']);
      }
    });
  }

  ngOnInit(): void {
  }

  Login() {
    let userData = this.formLogin.value as iUserLogin;
    console.log(userData);

    this._authService.login(userData).subscribe(
      (response) => {
        console.info('Response is: ', response);
        if (response.status) {
          this._snackBar.open(response.message, 'Ok', {
            duration: 2000,
            panelClass: ['success-snackbar'],
          });
          this.router.navigate(['/users']);
        }
      },
      (error) => {
        console.error('Error is: ', error);
        this._snackBar.open('Login failed', 'Ok', {
          duration: 2000,
          panelClass: ['red-snackbar'],
        });
      }
    );
    this.formLogin.reset();
  }
}
