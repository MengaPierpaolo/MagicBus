import { Component, Input } from '@angular/core';

import { SomethingGroovy } from './SomethingGroovy'

@Component({
  selector: 'something-groovy-list',
  template: `
    <h1>A List of Stuff (Clickable)</h1>
    <ul>
      <li *ngFor="let something of someData" (click)="clickMe(something)">
          <span>{{something.Title}}</span>
          -
          <span>{{something.SubTitle}}</span>
      </li>
    </ul>
    <h2 *ngIf="selectedSomething">{{selectedSomething.Title}}</h2>
    `,
})

export class SomethingGroovyListComponent {
  @Input() someData: SomethingGroovy[];
  
  selectedSomething: SomethingGroovy;
  
  clickMe(thing: SomethingGroovy) {
    this.selectedSomething = thing;
  }
}