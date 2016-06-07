import { Component, Input} from '@angular/core';
import { HomeViewModel } from '../model/homeViewModel';

@Component({
  selector: 'page-title',
  template: `
    <div class="jumbotron">
      <h1>{{title}}</h1>
      <h2>{{subTitle}}</h2>
    </div>
    `
})
export class PageTitleComponent {
  @Input() title: string;
  @Input() subTitle: string;
}