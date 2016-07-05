import '../../rxjs-operators.js';

import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { ToolbarComponent } from '../component/toolbar.component';

@Component({
  selector: 'tdiary-app',
  template: `
    <div class="container-fluid">
      <toolbar></toolbar>
      <router-outlet></router-outlet>
    </div>
    `,
  directives: [ROUTER_DIRECTIVES, ToolbarComponent]
})
export class AppComponent { }