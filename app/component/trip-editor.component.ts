import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm }    from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { Trip } from '../model/trip';

@Component({
  moduleId: module.id,
  selector: 'trip-editor',
  templateUrl: 'trip-editor.component.html',
  directives: [PageTitleComponent]
})
export class TripDetailComponent {
  constructor(private router: Router) {
    this.model = new Trip();
  }

  model: Trip;
  transport = ['Bus', 'Train', 'Plane'];

  onSubmit() {
    this.router.navigateByUrl('dashboard');
  }

  goBack() {
    this.router.navigateByUrl('dashboard');
  }
}