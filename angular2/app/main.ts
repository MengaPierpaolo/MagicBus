import { AppComponent } from './component/app';
import { bootstrap } from '@angular/platform-browser-dynamic';

import { APP_ROUTER_PROVIDERS } from './app.routes';
import { HTTP_PROVIDERS } from '@angular/http';

import {disableDeprecatedForms, provideForms} from '@angular/forms';

bootstrap(AppComponent,
  [
    disableDeprecatedForms(),
    provideForms(),
    APP_ROUTER_PROVIDERS,
    HTTP_PROVIDERS
  ])
  .catch(err => console.error(err));