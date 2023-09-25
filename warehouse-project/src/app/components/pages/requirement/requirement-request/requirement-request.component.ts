import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NewRequiModalComponent } from 'src/app/components/modals/new-requi-modal/new-requi-modal.component';
import { Iitem } from 'src/app/models/Iitem';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-requirement-request',
  templateUrl: './requirement-request.component.html',
  styleUrls: ['./requirement-request.component.scss']
})
export class RequirementRequestComponent {
  //displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  displayedColumns: string[] = ['code', 'name', 'description',  'material', 'category', 'measure','unit', 'quantity', 'actions'];
  itemsRequested: Iitem[] = [
  ];
  dataSource = new MatTableDataSource<Iitem>();
  constructor(public dialog: MatDialog) {
    this.dataSource.data = this.itemsRequested;
  }

  openModal(){
    const dialogRef = this.dialog.open(NewRequiModalComponent, {
      width: '600px',
      data: {items : this.itemsRequested}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.test();
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

}
