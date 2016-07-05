import { Component } from '@angular/core';

import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
  selector: 'tdiary-app',
  template: `
    <div class="container-fluid">
      <router-outlet></router-outlet>
    </div>
    `,
  directives: [ROUTER_DIRECTIVES]
})
export class AppComponent { }