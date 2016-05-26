import { Component, Input } from '@angular/core';

import { SomethingGroovy } from './SomethingGroovy'

@Component({
  selector: 'something-groovy-list',
  template: `
    <form class="form-inline">
    <label>A List of Stuff (Clickable)</label>
    <ul>
      <li *ngFor="let something of someData" (click)="clickMe(something)">
          <span>{{something.Title}}</span>
          -
          <span>{{something.SubTitle}}</span>
      </li>
    </ul>
    <label *ngIf="selectedSomething">{{selectedSomething.Title}}</label>
    </form>
    `,
})

export class SomethingGroovyListComponent {
  @Input() someData: SomethingGroovy[];
  
  selectedSomething: SomethingGroovy;
  
  clickMe(thing: SomethingGroovy) {
    this.selectedSomething = thing;
  }
}