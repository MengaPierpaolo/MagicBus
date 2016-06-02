import { Component, Input } from '@angular/core';
import { ActivityViewModel } from '../model/activityViewModel'

@Component({
  selector: 'experience-list',
  template: `
    <form class="form-inline">
    <label>Recent experiences:</label>
      <div *ngFor="let activity of activityData">
          <a href="#" (click)="clickMe(activity)" class="delete-cross">X</a>
          <a href="#" (click)="clickMe(activity)">{{activity.Experience}}</a>
      </div>
    <label *ngIf="selectedActivity">{{selectedActivity.Experience}}</label>
    </form>
    `,
})

export class ExperienceListComponent {
  @Input() activityData: ActivityViewModel[];
  
  selectedActivity: ActivityViewModel;
  
  clickMe(clickedThing: ActivityViewModel) {
    this.selectedActivity = clickedThing;
  }
}