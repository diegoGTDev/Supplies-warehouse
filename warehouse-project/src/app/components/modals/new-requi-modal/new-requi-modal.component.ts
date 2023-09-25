import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Iitem } from '../../../models/Iitem';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-new-requi-modal',
  templateUrl: './new-requi-modal.component.html',
  styleUrls: ['./new-requi-modal.component.scss'],
})


export class NewRequiModalComponent {
  dataSource : any = [];
  Item!: Iitem;
  requi_item_form = this._formBuilder.group({
    code: ['', ],
    name: ['' , ],
    unit: ['', Validators.required],

  });

  constructor(private _formBuilder : FormBuilder,
              private _dialogRef : MatDialogRef<NewRequiModalComponent>,
              @Inject(MAT_DIALOG_DATA) public data: {items: Iitem[]}) { }

  addNewItem(){
    // this.Conceptos.push(this.requi_item_form.value);
    // this.requi_item_form.reset();
    console.log(this.requi_item_form.value);
    this.Item = {
      'code' :this.requi_item_form.value.code!,
      'name' :this.requi_item_form.value.name!,
      'unit': Number(this.requi_item_form.value.unit)!,
      'description': '',
      'category': '',
      'measure': 0,
      'material': '',
      'location': '',
      'quantity': 0,


    };

    this.data.items.push(this.Item);
    this.close();
  }

  close(){

    this._dialogRef.close();
    return "Hello";
  }
}
