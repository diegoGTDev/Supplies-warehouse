import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from './environment';
import { Iitem } from '../core/models/Iitem';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private route = environment.apiUrl;
  constructor(private http: HttpClient) { }

  post(item: Iitem){
    return this.http.post(`${this.route}/item`, item);
  }
  getItems(){
    var response = new Observable;
    response = this.http.get(`${this.route}/item`);
    return response.pipe(
      map((res: any) => {
        return res;
      })
    );
    // try{

    //   response = this.http.get(`${this.route}/item`);
    // }catch(error){
    //   console.info("The error was: ", error);
    // }
    // return response.pipe(
    //   map((res: any) => {
    //     return res;
    //   })
    // );
  }
}
