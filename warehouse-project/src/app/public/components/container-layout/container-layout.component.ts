import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
    selector: 'app-container-layout',
    standalone: true,
    imports: [
        CommonModule,
    ],
    template: `<div class="container"><ng-content></ng-content></div>`,
    styleUrls: ['./container-layout.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ContainerLayoutComponent { }
