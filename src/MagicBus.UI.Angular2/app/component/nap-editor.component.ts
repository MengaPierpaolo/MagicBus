import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { DataService } from '../service/data.service';
import { Nap } from '../model/nap';

@Component({
  moduleId: module.id,
  selector: 'nap-editor',
  templateUrl: 'nap-editor.component.html',
  directives: [PageTitleComponent],
  providers: [DataService]
})
export class NapDetailComponent implements OnInit {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dataService: DataService
  ) {
    this.model = new Nap();
  }

  model: Nap;
  private errorMessage: any;

  ngOnInit() {
    this.route
      .params
      .subscribe(params => {
        let id = +params['id'];
        var activity = this.dataService.getActivity('Nap', id)
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
    this.router.navigate(['dashboard']);
  }
}