import { Injectable } from '@angular/core';
import { environment } from '../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRequirement } from 'src/app/core/models/Irequirement';

@Injectable({
  providedIn: 'root'
})
export class RequirementService {

  private url = environment.apiUrl + '/requirement';
  constructor(private _http : HttpClient) {

   }

   sendRequirement(Requirement: IRequirement){
    console.info("The requirement is: service  ", Requirement);
    return this._http.post<Response>(this.url, Requirement).subscribe();

   }

   getAllRequirements(){
      return this._http.get<Response>(this.url);
   }

}
