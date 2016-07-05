import { provideRouter, RouterConfig } from '@angular/router';
import { DashboardComponent } from './component/dashboard.component'
import { SightDetailComponent } from './component/sight-editor.component'
import { TripDetailComponent } from './component/trip-editor.component'
import { ChowDetailComponent } from './component/chow-editor.component'
import { NapDetailComponent } from './component/nap-editor.component'

export const routes: RouterConfig = [
  { path: '', component: DashboardComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'trip', component: TripDetailComponent },
  { path: 'sight', component: SightDetailComponent },
  { path: 'chow', component: ChowDetailComponent },
  { path: 'nap', component: NapDetailComponent }
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];
