import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './environment';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private route = environment.apiUrl;
  constructor(private http: HttpClient) { }


  getItems(){
    var response = new Observable;
    try{

      response = this.http.get(`${this.route}/item`);
    }catch(error){
      console.info("The error was: ", error);
    }
    return response;
  }
}
