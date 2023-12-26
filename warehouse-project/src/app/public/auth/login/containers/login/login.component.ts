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
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  formLogin: FormGroup;
  hidePassword:boolean   = true;
  loading: boolean = false;


  constructor(
    private fb: FormBuilder,
    private router: Router,
    private _snackBar: MatSnackBar,
    private _authService: AuthService
  ) {
    this.formLogin = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
    this._authService.user.subscribe((e) =>{
      if (e){
        this.router.navigate(['/pages'])
      }
    })
  }

  ngOnInit(): void {
    this._authService.verifySession().subscribe(response =>{
      console.info("Mi responsita", response);
      if (response.data){
        this.router.navigate(['/pages']);
      }
      else{
        //alert("Error");
      }
    });
  }

  Login(){
    let userData = this.formLogin.value as iUserLogin;
    console.log(userData);

      this._authService.login(userData).subscribe(response =>{
        console.info(response);
        if (response.status){
          this._snackBar.open(response.message, "Ok", {
            duration: 2000,
            panelClass: ['sucess-snackbar']
          });
          this.router.navigate(['/pages']);
        }
      },
      error =>{
        this._snackBar.open("Login failed", "Ok", {
          duration: 2000,
          panelClass: ['red-snackbar']
        });
      }
      )
      this.formLogin.reset();
  }

}
