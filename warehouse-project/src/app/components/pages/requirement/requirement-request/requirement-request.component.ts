import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NewRequiModalComponent } from 'src/app/components/modals/new-requi-modal/new-requi-modal.component';
import { Iitem } from 'src/app/core/models/Iitem';
import { IRequirement } from 'src/app/core/models/Irequirement';
import { Status } from 'src/app/core/models/Status';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-requirement-request',
  templateUrl: './requirement-request.component.html',
  styleUrls: ['./requirement-request.component.scss'],
})
export class RequirementRequestComponent {
  //For the table
  displayedColumns: string[] = [
    'code',
    'name',
    'description',
    'material',
    'category',
    'unit',
    'measure',
    'actions',
  ];
  isEditing: boolean[] = [];
  editedData: any[] = [];
  dataSource = new MatTableDataSource<Iitem>();
  //For the requirement
  itemsRequested: Iitem[] = [];
  requirement: IRequirement;
  //The form for requirement
  //Make a formbuilder
  _requiForm = this._formBuilder.group({
    description: [''],
  });

  constructor(public dialog: MatDialog, private _formBuilder: FormBuilder, private _snackBar :MatSnackBar) {
    this.dataSource.data = this.itemsRequested;
    this.isEditing = Array(this.dataSource.data.length).fill(false);
    this.editedData = this.dataSource.data.map((item) => ({
      units: item.units,
    }));
    this.requirement = {
      user: 'User',
      description: 'Description',
      status: Status.Open,
      concepts: this.itemsRequested,
    };
  }
  openModal() {
    const dialogRef = this.dialog.open(NewRequiModalComponent, {
      width: '900px',
      data: { items: this.itemsRequested },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.editedData = this.dataSource.data.map((item) => ({
        units: item.units,
      }));
      this.dataSource.data = this.itemsRequested;
    });
  }
  test() {
    console.log(this.itemsRequested);
    this.dataSource.data = this.itemsRequested;
    this.requirement.description = this._requiForm.value.description
      ? this._requiForm.value.description
      : this.requirement.description;
    console.info('The requirement is: ', this.requirement);
  }
  doneRequirement() {
    let message : string;
    let warning : Boolean = false;
    if (this.itemsRequested.length < 1){
      message = 'You must add at least one item to the requirement';
      warning = true;
    }
    else if (this._requiForm.value.description == ''){
      message = 'You must add a description to the requirement';
      warning = true;
    }
    else{
      message = 'Requirement done';
      this._requiForm.reset();
      this.itemsRequested = [];
      this.dataSource.data = this.itemsRequested;
    }
    this.requirement.description = this._requiForm.value.description
      ? this._requiForm.value.description
      : this.requirement.description;
    this._snackBar.open(message, 'Close', {
        duration: 1500,
        horizontalPosition: 'center',
        verticalPosition: 'top',
        panelClass: warning ? ['red-snackbar'] : ['sucess-snackbar']

      });
  }
  deleteElement(element: Iitem) {
    const index = this.itemsRequested.indexOf(element);
    this.itemsRequested.splice(index, 1);
    this.dataSource.data = this.itemsRequested;
  }

  // Función para habilitar la edición de una celda
  editCell(index: number) {
    this.isEditing[index] = true;
  }

  // Función para guardar una celda editada y deshabilitar la edición
  saveCell(index: number) {
    this.isEditing[index] = false;

    // Obtén el nuevo valor del campo "Unit" desde editedData
    const newValue = this.editedData[index].units;

    // Actualiza la fuente de datos con el nuevo valor
    this.dataSource.data[index].units = newValue;
  }
}
