import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm }    from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { DataService } from '../service/data.service';
import { Trip } from '../model/trip';

@Component({
  moduleId: module.id,
  selector: 'trip-editor',
  templateUrl: 'trip-editor.component.html',
  directives: [PageTitleComponent],
  providers: [DataService]
})
export class TripDetailComponent implements OnInit {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dataService: DataService
  ) {
    this.model = new Trip();
  }

  model: Trip;
  transport = ['Bus', 'Train', 'Plane'];

  private id: number;

  ngOnInit() {
    this.route
      .params
      .subscribe(params => {
        let id = +params['id'];
        this.dataService.getTrip(id)
          .then(blah => {
            if (blah) {
              this.model = new Trip();
              this.model.From = blah.ExperienceType; // TODO:
            } else { // id not found

            }
          });
      });
  }

  onSubmit() {
    this.router.navigateByUrl('dashboard');
  }

  goBack() {
    this.router.navigateByUrl('dashboard');
  }
}
