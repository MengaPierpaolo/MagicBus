import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { Sight } from '../model/sight';

@Component({
  moduleId: module.id,
  selector: 'sight-editor',
  templateUrl: 'sight-editor.component.html',
  directives: [PageTitleComponent]
})
export class SightDetailComponent {
    constructor(private router: Router) {
    this.model = new Sight();
  }

  model: Sight;

  onSubmit() {
    this.router.navigate(['dashboard']);
  }

  goBack() {
    window.history.back();
    this.router.navigate(['dashboard']);
  }
}
