import { Component } from '@angular/core';
import { NgForm } from '@angular/common';
import { Router } from '@angular/router';

import { PageTitleComponent } from '../component/page-title.component';
import { Trip } from '../model/trip';

@Component({
  selector: 'editor',
  template: `
    <page-title [title]="'Life is a Journey'" [subTitle]="'Add your travel detail.'"></page-title>
    <div class="content">
        <form class="form" (ngSubmit)="onSubmit()" #thisForm="ngForm" autocomplete="off">
          <div class="form-group">
              <label for="date">On</label>
              <input class="form-control date" type="text" for="date" required autocomplete="off" [(ngModel)]="model.date" ngControl="date" #date="ngForm">
              <div [hidden]="date.valid || date.pristine" class="alert alert-danger">
                Date is required.
              </div>
          </div>
          <div class="form-group">
              <label for="from">You travelled from</label>
              <input class="form-control" type="text" for="from" autocomplete="off" required [(ngModel)]="model.from" ngControl="from" #from="ngForm">
              <div [hidden]="from.valid || from.pristine" class="alert alert-danger">
                From is Required
              </div>
          </div>
          <div class="form-group">
              <label for="to">To</label>
              <input class="form-control" type="text" for="to" autocomplete="off" required [(ngModel)]="model.to" ngControl="to" #to="ngForm">
              <div [hidden]="to.valid || to.pristine" class="alert alert-danger">
                To is Required
              </div>
          </div>
          <div class="form-group">
            <label for="transport">By</label>
            <select class="form-control" required [(ngModel)]="model.by">
              <option *ngFor="let t of transport" [value]="t">{{t}}</option>
            </select>
          </div>
          <button type="submit" class="btn btn-primary" [disabled]="!thisForm.form.valid">Save it!</button>
          <button type="button" class="btn btn-info" (click)="goBack()">Changed my mind</button>
        </form>
    </div>
  `,
  directives: [PageTitleComponent]
})
export class TripDetailComponent {
  constructor(private router: Router) {
    this.model = new Trip('', '', '', 'Bus');
  }

  model: Trip;
  transport = ['Bus', 'Train', 'Plane'];

  onSubmit() {
    // TODO: Save
    this.router.navigateByUrl('dashboard');
  }

  goBack() {
    this.router.navigateByUrl('dashboard');
  }
}