import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ContainerLayoutComponent } from 'src/app/public/components/container-layout/container-layout.component';
import { ItemAttributeService } from 'src/app/services/itemAttributes/itemAttributeService';
import { ItemAttributeResponse } from 'src/app/core/models/ItemAttributesResponse';
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
  attributes? : ItemAttributeResponse;
  categories  : String[]= [];
  materials : String[] = [];
  measures  : String[]= [];
  locations  : String[]= [];
  constructor(private _formBuilder : FormBuilder, private _itemAttributeService: ItemAttributeService) {

   }

  //Onload
  ngOnInit(){
    this._itemAttributeService.getAll().subscribe(
      (data) => {
        this.attributes= data;
        this.categories = this.attributes.category;
        this.materials = this.attributes.material;
        this.measures = this.attributes.measure;
        this.locations = this.attributes.location;

      }
    );
  }
}

