import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NewRequiModalComponent } from 'src/app/components/modals/new-requi-modal/new-requi-modal.component';
import { Iitem } from 'src/app/core/models/Iitem';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-requirement-request',
  templateUrl: './requirement-request.component.html',
  styleUrls: ['./requirement-request.component.scss']
})
export class RequirementRequestComponent {
  //displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  displayedColumns: string[] = ['code', 'name', 'description',  'material', 'category', 'unit', 'measure', 'actions'];
  itemsRequested: Iitem[] = [

  ];
  isEditing: boolean[] = [];
  editedData: any[] = [];
  dataSource = new MatTableDataSource<Iitem>();
  constructor(public dialog: MatDialog) {
    this.dataSource.data = this.itemsRequested;
    this.isEditing = Array(this.dataSource.data.length).fill(false);
    this.editedData = this.dataSource.data.map(item => ({ units: item.units }));
  }

  openModal(){
    const dialogRef = this.dialog.open(NewRequiModalComponent, {
      width: '900px',
      data: {items : this.itemsRequested}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.test();
      this.editedData = this.dataSource.data.map(item => ({ units: item.units }));
    });
  }
  test(){
    console.log(this.itemsRequested);
    this.dataSource.data = this.itemsRequested;
  }
  sendRequirement(){
    //Working on...
  }
  deleteElement(element : Iitem){
    const index = this.itemsRequested.indexOf(element);
    this.itemsRequested.splice(index,1);
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
