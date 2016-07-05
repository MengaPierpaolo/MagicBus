import { Component, Input } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { ActivityViewModel } from '../viewModel/activityViewModel'
import { DataService } from '../service/data.service';

@Component({
  selector: 'experience-list',
  template: `
    <form class="form-inline">
    <h3>Recent experiences:</h3>
      <div *ngFor="let activity of activityData">
          <a href="#" (click)="clickMe(activity)" class="delete-cross">X</a>
          <a [routerLink]="['/' + activity.ExperienceType, activity.Id]">{{activity.Experience}}</a>
      </div>
    <label *ngIf="selectedActivity">{{selectedActivity.Experience}}</label>
    </form>
    `,
  directives: [ ROUTER_DIRECTIVES ],
  providers: [ DataService ]
})

export class ExperienceListComponent {
  constructor(private dataService: DataService) {
    dataService.getRecentExperiences()
      .then(experiences => this.activityData = experiences);;
  }

  activityData: ActivityViewModel[];
  selectedActivity: ActivityViewModel;

  clickMe(clickedThing: ActivityViewModel) {
    this.selectedActivity = clickedThing;
    return false;
  }
}