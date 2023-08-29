import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NewRequiModalComponent } from 'src/app/components/modals/new-requi-modal/new-requi-modal.component';
import { Iitem } from 'src/app/models/Iitem';
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];
@Component({
  selector: 'app-requirement-request',
  templateUrl: './requirement-request.component.html',
  styleUrls: ['./requirement-request.component.scss']
})
export class RequirementRequestComponent {
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  // displayedColumns: string[] = ['code', 'name', 'description', 'category',"material", 'unit', 'quantity'];
  itemsRequested: Iitem[] = [];
  dataSource = ELEMENT_DATA
  constructor(public dialog: MatDialog) { }

  openModal(){
    const dialogRef = this.dialog.open(NewRequiModalComponent, {
      width: '600px',
      data: {items : this.itemsRequested}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
  test(){
    console.log(this.itemsRequested);
  }
  sendRequirement(){
    //Working on...
  }
  
}
