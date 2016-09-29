import { Component, Input } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { ActivityViewModel } from '../viewModel/activityViewModel'
import { DataService } from '../service/data.service';

@Component({
  selector: 'experience-list',
  template: `
    <form class="form-inline">
    <h3>Recent experiences:</h3>
      <div class="experience" *ngFor="let activity of activityData">
          <a class="clickable-experience" [routerLink]="['/' + activity.experienceType.toLowerCase(), activity.id]">{{activity.experience}}</a><br/>
          <a class="btn btn-default function-button glyphicon glyphicon-arrow-up" (click)="clickMe(activity)"></a>
          <a class="btn btn-default function-button glyphicon glyphicon-arrow-down" (click)="clickMe(activity)"></a>
          <a class="btn btn-default function-button glyphicon glyphicon-remove" (click)="clickMe(activity)"></a>
      </div>
    </form>
    `,
  directives: [ROUTER_DIRECTIVES],
  providers: [DataService]
})

export class ExperienceListComponent {
  constructor(private dataService: DataService) {
    this.dataService.getRecentExperiences()
      .subscribe(
      data => this.activityData = data,
      error => this.errorMessage = <any>error);
  }

  private errorMessage: any;

  activityData: ActivityViewModel[];
  selectedActivity: ActivityViewModel;

  clickMe(clickedThing: ActivityViewModel) {
    this.selectedActivity = clickedThing;
    return false;
  }
}