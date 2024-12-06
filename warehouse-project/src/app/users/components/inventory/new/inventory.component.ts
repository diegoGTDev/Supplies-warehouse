import { Component } from '@angular/core';
import { FormBuilder, RequiredValidator, Validators } from '@angular/forms';
import { ContainerLayoutComponent } from 'src/app/public/components/container-layout/container-layout.component';
import { ItemAttributeService } from 'src/app/services/itemAttributes/itemAttributeService';
import { ItemAttributeResponse } from 'src/app/core/models/ItemAttributesResponse';
import { Iitem } from 'src/app/core/models/Iitem';
import { ItemService } from 'src/app/services/item.service';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
  selector: 'inventory-component',
})
export class InventoryComponent {

  public form = this._formBuilder.group({
    name: ['',Validators.required],
    description: ['', Validators.required],
    stock: ['', Validators.required],
    descriptions: ['', Validators.required],
    category: ['', Validators.required],
    code: ['', Validators.required],
    material: ['', Validators.required],
    measure: ['', Validators.required],
    location: ['', Validators.required],
  });
  attributes? : ItemAttributeResponse;
  categories  : String[]= [];
  materials : String[] = [];
  measures  : String[]= [];
  locations  : String[]= [];
  item : Iitem = {
    code : '',
    name : '',
    description: '',
    category : '',
    measure: '',
    material: '',
    location: '',
    quantity: 0
  }
  constructor(private _formBuilder : FormBuilder, private _itemAttributeService: ItemAttributeService, private _itemService : ItemService, private _snackBar: MatSnackBar) {

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
  //OnSubmit
  onSubmit(){
    var form = this.form.value;
    console.info("The form is: ", form);
    this.item = {
      code : form.code? form.code : '',
      name : form.name? form.name : '',
      description: form.description? form.description : '',
      category : form.category? form.category : '',
      measure: form.measure? form.measure : '',
      material: form.material? form.material : '',
      location: form.location? form.location : '',
      quantity: Number(form.stock)
    }
    console.info("The item is: ", this.item);
    this._itemService.post(this.item).subscribe(
        (data) => {
          console.log(data);
          this._snackBar.open("Item created successfully", "Close", {
            duration: 2000,
            panelClass: ['success-snackbar']
          });
          this.form.reset();
        },
        (error) => {
          console.error("Error creating item: ", error);
          this._snackBar.open("Error creating item", "Close", {
            duration: 2000,
            panelClass: ['red-snackbar']
          });
        }
      );
}

  limpiar(){
    this.form.reset();
  }
}

