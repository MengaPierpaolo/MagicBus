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
    <div class="jumbotron">
      <h1>{{something.Title}}</h1>
      <p>{{something.SubTitle}}</p>
    </div>
    <div class="row">
      <div class="col-sm-6">
        <form class="form-inline">
          <p><label>See how the Editing of this:</label></p>
          <p><input [(ngModel)]="something.Editable" class="form-control"></p>
          <p><label>changes this: </label></p>
          <p>{{something.Editable}}</p>
        </form>
      </div>
      <div class="col-sm-6">
        <something-groovy-list [someData]="getApplicationData()"></something-groovy-list>
      </div>
    </div>
    `,
    directives: [SomethingGroovyListComponent],
    providers: [DataService]
})

export class AppComponent { 
  constructor(private dataService: DataService)  {}

  something: SomethingGroovy = {
    Title: "Funky App",
    SubTitle: "Hello there Groovy Angular2 App!",
    Editable: "Editable Model Binding"
  }

  getApplicationData() : SomethingGroovy[] {
      return this.dataService.getSomeFunkyData();
  }  
}
