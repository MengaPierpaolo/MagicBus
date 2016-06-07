import { Component } from '@angular/core';
import { NgForm } from '@angular/common';
import { Router } from '@angular/router-deprecated';

import { PageTitleComponent } from '../component/page-title.component';
import { Chow } from '../model/chow';

@Component({
  selector: 'editor',
  template: `
    <page-title [title]="'Had some chow?'" [subTitle]="'Yum, add it to the list!'"></page-title>
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
                <label for="from">When you were in</label>
                <input class="form-control" type="text" for="location" autocomplete="off" required [(ngModel)]="model.location" ngControl="location" #location="ngForm">
                <div [hidden]="location.valid || location.pristine" class="alert alert-danger">
                  Location is required.
                </div>
            </div>
            <div class="form-group">
                <label for="to">You consumed</label>
                <input class="form-control" type="text" for="description" autocomplete="off" required [(ngModel)]="model.description" ngControl="description" #description="ngForm">
                <div [hidden]="description.valid || description.pristine" class="alert alert-danger">
                  The You consumed field is required.
                </div>
            </div>
          <button type="submit" class="btn btn-primary" [disabled]="!thisForm.form.valid">Save it!</button>
          <button type="button" class="btn btn-info" (click)="goBack()">Changed my mind</button>
        </form>
    </div>
  `,
  directives: [PageTitleComponent]
})
export class ChowDetailComponent {
  constructor(private router: Router) {
    this.model = new Chow('', '', '');
  }

  model: Chow;

  onSubmit() {
    // TODO: Save
    this.router.navigate(['/Dashboard']);
  }

  goBack() {
    this.router.navigate(['/Dashboard']);
  }
}