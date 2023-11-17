import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private route = "https://localhost:7155";
  constructor(private http: HttpClient) { }


  getItems(){
    var response = new Observable;
    try{

      response = this.http.get(`${this.route}/api/item`);
    }catch(error){
      console.info("The error was: ", error);
    }
    return response;
  }
}
