import { Component } from '@angular/core';
import { PageTitleComponent } from '../component/page-title.component';
import { ExperienceListComponent } from '../component/experience-list'

@Component({
  selector: 'tdiary-app',
  template: `
    <page-title></page-title>
    <div class="content row">
      <div class="col-sm-5">
          <h3>What'ya been up to?</h3>
          <button class="btn btn-primary btn-block">Been on a trip</button>
          <button class="btn btn-primary btn-block">Had some chow</button>
          <button class="btn btn-primary btn-block">Seen something funky</button>
          <button class="btn btn-default btn-block">Took a noteworthy nap</button>
      </div>
      <div class="col-sm-1"></div>
      <div class="col-sm-6">
        <experience-list></experience-list>
      </div>
    </div>
    `,
    directives: [PageTitleComponent, ExperienceListComponent]
})

export class AppComponent { 
}