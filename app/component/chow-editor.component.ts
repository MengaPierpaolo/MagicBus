import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { Chow } from '../model/chow';

@Component({
  moduleId: module.id,
  selector: 'chow-editor',
  templateUrl: 'chow-editor.component.html',
  directives: [PageTitleComponent]
})
export class ChowDetailComponent {
  constructor(private router: Router) {
    this.model = new Chow();
  }

  model: Chow;

  onSubmit() {
    this.router.navigate(['dashboard']);
  }

  goBack() {
    this.router.navigate(['dashboard']);
  }
}