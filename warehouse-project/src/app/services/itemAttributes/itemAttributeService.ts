import { Injectable } from '@angular/core';
import { environment } from '../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from 'src/app/core/models/Response';
import { ItemAttributeResponse } from 'src/app/core/models/ItemAttributesResponse';
@Injectable({
  providedIn: 'root'
})
export class ItemAttributeService {

  private url = environment.apiUrl + '/itemAttributes';
  constructor(private _http : HttpClient) {

  }
   getAll(){
      // return this._http.get<Response>(this.url).subscribe(
      //   (data : Response) => {
      //     return data;
      //   }
      // );
      var data;
      var response = this._http.get<ItemAttributeResponse>(`${this.url}`)
      console.log("Response was:", response);
      return response;
   }

}
