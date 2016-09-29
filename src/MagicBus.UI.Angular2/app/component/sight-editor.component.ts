import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { DataService } from '../service/data.service';
import { Sight } from '../model/sight';

@Component({
  moduleId: module.id,
  selector: 'sight-editor',
  templateUrl: 'sight-editor.component.html',
  directives: [PageTitleComponent],
  providers: [DataService]
})
export class SightDetailComponent implements OnInit {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dataService: DataService
  ) {
    this.model = new Sight();
  }

  model: Sight;
  private errorMessage: any;

  ngOnInit() {
    this.route
      .params
      .subscribe(params => {
        let id = +params['id'];
        var activity = this.dataService.getActivity('Sight', id)
          .subscribe(
          item => this.model = item,
          error => this.errorMessage = <any>error
          );
      });
  }

  onSubmit() {
    this.router.navigate(['dashboard']);
  }

  goBack() {
    window.history.back();
    this.router.navigate(['dashboard']);
  }
}
