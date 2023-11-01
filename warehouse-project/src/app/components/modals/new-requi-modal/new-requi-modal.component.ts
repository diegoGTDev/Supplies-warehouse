import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ItemService } from 'src/app/services/item.service';
import { Iitem } from 'src/app/core/models/Iitem';
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
  dataSource: any = [];
  filteredSource: any = [
    {code: '001', name: 'Item 1', description: 'Description 1', category: 'Category 1', measure: 'Measure 1', material: 'Material 1', location: 'Location 1', units: 0},
  ];
  Item!: Iitem;
  requi_item_form = this._formBuilder.group({
    code: [''],
    name: ['']
  });

  constructor(
    private _formBuilder: FormBuilder,
    private _dialogRef: MatDialogRef<NewRequiModalComponent>,
    private _itemService: ItemService,
    @Inject(MAT_DIALOG_DATA) public data: { items: Iitem[] }
  ) {}

  //*Gets all the items from the backend
  ngOnInit(): void {
    this._itemService.getItems().subscribe((data: any) => {
      console.log(data);
      this.dataSource = data;
      this.filteredSource = data;
    });
  }

  //*Searches for a item
  searchItem() {
    var searchByCode = this.requi_item_form.value.code?.toString().toUpperCase();
    var searchByName = this.requi_item_form.value.name?.toString().toLowerCase();

    if (searchByCode != '' || searchByCode != null && searchByName == '' || searchByName == null) {
      this.filteredSource = this.dataSource.filter( (item: any ) => item.code.startsWith(searchByCode));
    }
    else if (searchByCode == '' || searchByCode == null && searchByName != '' || searchByName != null){
      this.filteredSource = this.dataSource.filter( (item: any ) => item.name.toLowerCase().startsWith(searchByName));
    }
    else
    {
      this.filteredSource = this.dataSource;
    }
  }
  //*Gets the item Selected
  getItemSelected(event: any) {
    var itemSelected : Iitem;
    // Obtén la fila en la que se hizo clic
    const clickedRow = event.target.closest('tr');

    if (clickedRow) {
      // Accede a las celdas dentro de la fila
      const codeCell = clickedRow.querySelector('.item-code');
      const nameCell = clickedRow.querySelector('.item-name');
      const descriptionCell = clickedRow.querySelector('.item-description');
      const categoryCell = clickedRow.querySelector('.item-category');
      const measureCell = clickedRow.querySelector('.item-measure');
      const materialCell = clickedRow.querySelector('.item-material');
      const locationCell = clickedRow.querySelector('.item-location');

      if (codeCell){
        const codeValue = codeCell.textContent;
        console.log("Item code is: " + codeValue);

        itemSelected = {
          code: codeValue,
          name: nameCell?.textContent!,
          description: descriptionCell?.textContent!,
          category: categoryCell?.textContent!,
          measure: measureCell?.textContent!,
          material: materialCell?.textContent!,
          location: locationCell?.textContent!,
          units: 0
        };
        console.log(itemSelected);
        this.addNewItem(itemSelected);
      }
    }
  }
  //*Adds a item
  addNewItem(item : Iitem) {
    // this.Conceptos.push(this.requi_item_form.value);
    // this.requi_item_form.reset();
    this.data.items.push(item);
    this.close();
  }

  close() {
    this._dialogRef.close();
    return 'Hello';
  }
}
