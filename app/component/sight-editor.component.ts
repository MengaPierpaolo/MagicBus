import { Component } from '@angular/core';
import { PageTitleComponent } from '../component/page-title.component';

@Component({
  selector: 'sight-editor',
  template: `
    <page-title></page-title>
    <button class="btn btn-info" (click)="goBack()">Changed my mind</button>
  `,
  directives: [PageTitleComponent]
})
export class SightDetailComponent {
  goBack() {
    window.history.back();
  }
}
