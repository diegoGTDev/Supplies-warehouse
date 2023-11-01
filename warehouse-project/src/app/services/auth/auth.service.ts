import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { iUser } from 'src/app/core/models/iUser';
import { Response } from 'src/app/core/models/Response';
import { iUserLogin } from 'src/app/core/models/iUserLogin';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  isLoggedIn: Boolean = false;
  url: string = 'https://localhost:7155/api/user/login';
  rediectUrl: string | null = null;

  public userSubject!: BehaviorSubject<iUser>;
  public user!: Observable<iUser>;
  constructor(private _http: HttpClient) {
    this.userSubject = new BehaviorSubject<iUser>(
      JSON.parse(localStorage.getItem('user')!)
    );
    this.user = this.userSubject.asObservable();
  }

  login(login : iUserLogin): Observable<Response>{
    return this._http.post<Response>(this.url, login);
  }
}
