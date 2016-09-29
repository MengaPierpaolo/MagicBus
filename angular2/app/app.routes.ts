import { provideRouter, RouterConfig } from '@angular/router';
import { DashboardComponent } from './component/dashboard.component'
import { SightDetailComponent } from './component/sight-editor.component'
import { TripDetailComponent } from './component/trip-editor.component'
import { ChowDetailComponent } from './component/chow-editor.component'
import { NapDetailComponent } from './component/nap-editor.component'
import { ExperiencesComponent } from './component/experiences.component'

export const routes: RouterConfig = [
  { path: '', component: DashboardComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'trip', component: TripDetailComponent },
  { path: 'trip/:id', component: TripDetailComponent },
  { path: 'sight', component: SightDetailComponent },
  { path: 'sight/:id', component: SightDetailComponent },
  { path: 'chow', component: ChowDetailComponent },
  { path: 'chow/:id', component: ChowDetailComponent },
  { path: 'nap', component: NapDetailComponent },
  { path: 'nap/:id', component: NapDetailComponent },
  { path: 'experiences', component: ExperiencesComponent }
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];
