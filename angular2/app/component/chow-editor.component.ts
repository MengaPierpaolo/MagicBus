import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { DataService } from '../service/data.service';
import { Chow } from '../model/chow';

@Component({
  moduleId: module.id,
  selector: 'chow-editor',
  templateUrl: 'chow-editor.component.html',
  directives: [PageTitleComponent],
  providers: [DataService]
})
export class ChowDetailComponent implements OnInit {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dataService: DataService
  ) {
    this.model = new Chow();
  }

  model: Chow;

  private errorMessage: any;

  ngOnInit() {
    this.route
      .params
      .subscribe(params => {
        let id = +params['id'];
        var activity = this.dataService.getActivity('Chow', id)
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