import { Component } from '@angular/core';
import { RequirementService } from 'src/app/services/requirement/requirement.service';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'requirement-all-component',
  templateUrl: './requirement-all.component.html',
  styleUrls: ['./requirement-all.component.scss']
})
export class RequirementAllComponent {


  displayedColumns : string[] = ['ID', 'Description', 'Date'];
  DataSource : MatTableDataSource<any> = new MatTableDataSource<any>();
  constructor(private _requirementService : RequirementService) {
   }

  ngOnInit(): void {
    console.info("The requirement is: ", this._requirementService.getAllRequirements().subscribe(
      (e) =>{
        console.info("The response was: ", e);
        this.DataSource.data = e.data;
      }
    ));
  }

}
