import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ExperienceListComponent } from '../component/experience-list.component';
import { PageTitleComponent } from '../component/page-title.component';

@Component({
  selector: 'dashboard',
  template: `
    <page-title [title]="'Magic Bus'" [subTitle]="'Your groovy new travel diary - In Angular 2!'"></page-title>
    <div class="content row">
      <div class="col-sm-5">
          <h3>What'ya been up to?</h3>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('trip')">Been on a trip</button>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('chow')">Had some chow</button>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('sight')">Saw something funky</button>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('nap')">Took a noteworthy nap</button>
      </div>
      <div class="col-sm-1"></div>
      <div class="col-sm-6">
        <experience-list></experience-list>
      </div>
    </div>
    `,
  directives: [
    PageTitleComponent,
    ExperienceListComponent
  ]
})
export class DashboardComponent {
  constructor(private router: Router) { }

  gotoDetail(where: string) {
    let link = [where];
    this.router.navigate(link);
  }
}