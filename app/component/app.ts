import { Component } from '@angular/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

import { PageTitleComponent } from '../component/page-title.component';
import { DashboardComponent } from '../component/dashboard.component';
import { TripDetailComponent } from '../component/trip-editor.component';
import { SightDetailComponent } from '../component/sight-editor.component';
import { ChowDetailComponent } from '../component/chow-editor.component';

@Component({
  selector: 'tdiary-app',
  template: `
    <div class="container-fluid">
      <router-outlet></router-outlet>
    </div>
    `,
  directives: [ROUTER_DIRECTIVES, PageTitleComponent, DashboardComponent, TripDetailComponent],
  providers: [
    ROUTER_PROVIDERS
  ]
})
@RouteConfig([
  { path: '/', name: 'root', redirectTo: ['/Dashboard']  },
  { path: '/Dashboard', name: 'Dashboard', component: DashboardComponent },
  { path: '/Trip', name: 'Trip', component: TripDetailComponent },
  { path: '/Sight', name: 'Sight', component: SightDetailComponent },
  { path: '/Chow', name: 'Chow', component: ChowDetailComponent },
])
export class AppComponent { }