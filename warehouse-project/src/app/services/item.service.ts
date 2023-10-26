import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private route = "https://localhost:7155";
  constructor(private http: HttpClient) { }


  getItems(){
    return this.http.get(`${this.route}/api/item`);
  }
}
