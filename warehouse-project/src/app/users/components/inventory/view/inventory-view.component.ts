import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ContainerLayoutComponent } from '../../../../public/components/container-layout/container-layout.component';
import { ItemService } from 'src/app/services/item.service';
import { MatTableDataSource } from '@angular/material/table';
import { Iitem } from 'src/app/core/models/Iitem';

@Component({
  selector: 'app-inventory-view',
  templateUrl: './inventory-view.component.html',
  styleUrls: ['./inventory-view.component.css'],
})
export class InventoryViewComponent {
  dataSource = new MatTableDataSource<Iitem>();
  displayedColumns: string[] = [
    'code',
    'name',
    'description',
    'material',
    'category',
    'stock',
    'measure',
    'actions',
  ];

  constructor(private _itemService: ItemService) {}
  ngOnInit(): void {
    try {
      this._itemService.getItems().subscribe((data: any) => {
        console.log('The data is: ', data);
        // catchError((err) => {
        //   console.log("Error: ", err);
        //   return err;
        // }
        // );
        this.dataSource = data;
      });
    } catch (error) {
      console.log('CACA');
      console.log('Error: ', error);
    }
  }
}
