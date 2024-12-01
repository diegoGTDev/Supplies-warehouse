import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ContainerLayoutComponent } from 'src/app/public/components/container-layout/container-layout.component';
@Component({
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
  selector: 'inventory-component',
})
export class InventoryComponent {

  public form = this._formBuilder.group({
    name: [''],
    description: [''],
    stock: [''],
    descriptions: [''],
    category: [''],
    code: [''],
    material: [''],
    measure: [''],
    location: [''],
  });
  constructor(private _formBuilder : FormBuilder){

  }
}
