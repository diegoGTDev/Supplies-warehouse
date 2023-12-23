import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { iUser } from 'src/app/core/models/iUser';
import { Response } from 'src/app/core/models/Response';
import { iUserLogin } from 'src/app/core/models/iUserLogin';
import { environment } from '../environment';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url: string = environment.apiUrl + '/user';
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
    return this._http.post<Response>(`${this.url}/login`, login).pipe(
      map(res =>{
        if (res.status === 1){
          console.info("login: ", login);
          const user : iUser = res.data as iUser;
          console.log("User: ", res.data);
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

  verifySession() : Observable<any>{
    let user = JSON.parse(localStorage.getItem('user')!);
    return this._http.post<Response>(`${this.url}/VerifySession`, user);

  }


  get userData(): Observable<iUser>{
    return this.user;
  }
  get userToken() : any {
    let user = JSON.parse(localStorage.getItem('user')!);
    return user.token;
  }
  get test(){
    if (localStorage.getItem('user') != null){
      return JSON.parse(localStorage.getItem('user')!);
    }
    return this.userSubject.value;
  }
  get userLoginOn(): Observable<Boolean>{
    this.verifySession().subscribe(response =>{
      console.info("Mi responsita", response);
      if (response.data){
        this.currentUserLoginOn.next(true);
      }
      else{
        this.currentUserLoginOn.next(false);
      }
    });
    // this.userToken ? this.currentUserLoginOn.next(true) : this.currentUserLoginOn.next(false);
    return this.currentUserLoginOn.asObservable();
  }
}
