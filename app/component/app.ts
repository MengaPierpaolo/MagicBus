import { Component } from '@angular/core';
import { HomeViewModel } from '../model/homeViewModel';
import { ActivityViewModel } from '../model/activityViewModel';
import { ExperienceListComponent } from '../component/experience-list'
import { DataService } from '../service/data.service'

@Component({
  selector: 'tdiary-app',
  template: `
    <div class="jumbotron">
      <h1>{{pageDetails.Title}}</h1>
      <h2>{{pageDetails.SubTitle}}</h2>
    </div>
    <div class="content row">
      <div class="col-sm-6">
          <label>Wotcha been up to?</label><br>
          <button class="btn btn-primary">Been on a trip</button>
          <button class="btn btn-primary">Had some chow</button>
          <button class="btn btn-primary">Seen something funky</button>
      </div>
      <div class="col-sm-6">
        <experience-list [activityData]="getApplicationData()"></experience-list>
      </div>
    </div>
    `,
    directives: [ExperienceListComponent],
    providers: [DataService]
})

export class AppComponent { 
  constructor(private dataService: DataService)  {}

  pageDetails: HomeViewModel = {
    Title: "Magic Bus",
    SubTitle: "Your groovy new travel diary - In Angular 2!"
  }

  getApplicationData() : ActivityViewModel[] {
      return this.dataService.getRecentExperiences();
  }  
}