import {disableDeprecatedForms, provideForms} from '@angular/forms';

import { bootstrap } from '@angular/platform-browser-dynamic';
import { AppComponent } from './component/app';
import { APP_ROUTER_PROVIDERS } from './app.routes';

bootstrap(AppComponent,
  [
    disableDeprecatedForms(),
    provideForms(),
    APP_ROUTER_PROVIDERS
  ])
  .catch(err => console.error(err));