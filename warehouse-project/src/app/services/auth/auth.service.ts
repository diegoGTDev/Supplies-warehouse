import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { iUser } from 'src/app/core/models/iUser';
import { Response } from 'src/app/core/models/Response';
import { iUserLogin } from 'src/app/core/models/iUserLogin';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url: string = 'https://localhost:7155/api/user/login';
  rediectUrl: string | null = null;

  public userSubject!: BehaviorSubject<iUser>;
  public currentUserLoginOn : BehaviorSubject<Boolean> = new BehaviorSubject<Boolean>(false);
  public user!: Observable<iUser>;
  constructor(private _http: HttpClient) {
    this.userSubject = new BehaviorSubject<iUser>(
      JSON.parse(localStorage.getItem('user')!)
    );
    this.user = this.userSubject.asObservable();
  }

  login(login : iUserLogin): Observable<Response>{
    return this._http.post<Response>(this.url, login).pipe(
      map(res =>{
        if (res.status === 1){
          const user : iUser = res.data as iUser;
          localStorage.setItem('user', JSON.stringify(user));
          this.userSubject.next(user);
          this.currentUserLoginOn.next(true);
        }
        return res;
      })
    );
  }

  logout(): void{
    localStorage.removeItem('user');
    this.userSubject.next(null!);
    this.currentUserLoginOn.next(false);
  }

  get userData(): Observable<iUser>{
    return this.user;
  }
  get userLoginOn(): Observable<Boolean>{
    return this.currentUserLoginOn.asObservable();
  }
}
