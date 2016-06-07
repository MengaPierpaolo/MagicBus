import { Component, Input } from '@angular/core';
import { ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router';
import { ActivityViewModel } from '../model/activityViewModel'
import { DataService } from '../service/data.service';

@Component({
  selector: 'experience-list',
  template: `
    <form class="form-inline">
    <h3>Recent experiences:</h3>
      <div *ngFor="let activity of activityData">
          <a href="#" (click)="clickMe(activity)" class="delete-cross">X</a>
          <a href="/Trip">{{activity.Experience}}</a>
      </div>
    <label *ngIf="selectedActivity">{{selectedActivity.Experience}}</label>
    </form>
    `,
    directives: [ROUTER_DIRECTIVES], 
    providers: [ROUTER_PROVIDERS, DataService]
})

export class ExperienceListComponent {
  constructor(private dataService: DataService) {
    this.activityData = dataService.getRecentExperiences();
  }

  activityData: ActivityViewModel[];
  selectedActivity: ActivityViewModel;

  clickMe(clickedThing: ActivityViewModel) {
    this.selectedActivity = clickedThing;
    return false;
  }
}