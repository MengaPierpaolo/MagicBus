import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/common';
import { NgModel, FormGroup } from '@angular/forms';

import { PageTitleComponent } from '../component/page-title.component';
import { Nap } from '../model/nap';

@Component({
  moduleId: module.id,
  selector: 'nap-editor',
  templateUrl: 'nap-editor.component.html',
  directives: [PageTitleComponent]
})
export class NapDetailComponent {
  constructor(private router: Router) {
    this.model = new Nap();
  }

  model: Nap;

  onSubmit() {
    this.router.navigate(['dashboard']);
  }

  goBack() {
    this.router.navigate(['dashboard']);
  }
}