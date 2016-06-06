import { Component } from '@angular/core';
import { Router } from '@angular/router-deprecated';
import { ExperienceListComponent } from '../component/experience-list.component';
import { PageTitleComponent } from '../component/page-title.component';

@Component({
  selector: 'dashboard',
  template: `
    <page-title></page-title>
    <div class="content row">
      <div class="col-sm-5">
          <h3>What'ya been up to?</h3>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('Trip')">Been on a trip</button>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('Chow')">Had some chow</button>
          <button class="btn btn-primary btn-block" (click)="gotoDetail('Sight')">Saw something funky</button>
          <button class="btn btn-default btn-block" (click)="todo()">Took a noteworthy nap</button>
      </div>
      <div class="col-sm-1"></div>
      <div class="col-sm-6">
        <experience-list></experience-list>
      </div>
    </div>
    `,
  directives: [ExperienceListComponent, PageTitleComponent]
})
export class DashboardComponent {

  constructor(
    private router: Router) {
  }

  gotoDetail(where: string) {
    let link = [where];
    this.router.navigate(link);
  }
  
  todo(){
    alert('Sleeping on it');
  }
}