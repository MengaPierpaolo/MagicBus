// ng2 stuff
import { Component } from '@angular/core';

// Used Components
// Classes
import { SomethingGroovy } from './somethingGroovy';
// Partials
import { SomethingGroovyListComponent } from './something-groovy-list'

// My Services
import { DataService } from './data.service'

@Component({
  selector: 'my-app',
  template: `
    <h1>{{something.Title}}</h1>
    <h1>{{something.SubTitle}}</h1>
    <h3>{{something.Editable}}</h3>
    <input [(ngModel)]="something.Editable">
    <hr />
    <something-groovy-list [someData]="getApplicationData()">
    `,
    directives: [SomethingGroovyListComponent],
    providers: [DataService]
})

export class AppComponent { 
  constructor(private dataService: DataService)  {}

  something: SomethingGroovy = {
    Title: "Hmmm ng2",
    SubTitle: "Working Examples",
    Editable: "Edit Me"
  }

  getApplicationData() : SomethingGroovy[] {
      return this.dataService.getSomeFunkyData();
  }  
}
