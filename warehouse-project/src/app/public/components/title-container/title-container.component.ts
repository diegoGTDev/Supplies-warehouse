import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-title-container',
  standalone: true,
  imports: [
    CommonModule
  ],
  template: `<h1 class="title"><strong><ng-content></ng-content></strong></h1>`,
  styleUrls: ['./title-container.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TitleContainerComponent { }
