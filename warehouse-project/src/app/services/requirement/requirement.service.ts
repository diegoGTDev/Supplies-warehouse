import { Injectable } from '@angular/core';
import { environment } from '../environment';

@Injectable({
  providedIn: 'root'
})
export class RequirementService {

  private url = environment.apiUrl + 'requirement';
  constructor() { }

}
