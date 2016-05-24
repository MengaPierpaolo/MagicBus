import { Injectable } from '@angular/core';

import { SomethingGroovy } from './SomethingGroovy'

@Injectable()
export class DataService {
    getSomeFunkyData() : SomethingGroovy[] {
        return STUFF;
    }
}

var STUFF: SomethingGroovy[] = [
  { "Title": "Practical Things", "SubTitle": "Ben", "Editable": "Hello" },
  { "Title": "Impossible Stories", "SubTitle": "John", "Editable": "Hello" },
  { "Title": "Rare Birds", "SubTitle": "Bill", "Editable": "Hello" },
  { "Title": "Enlightened Sugar", "SubTitle": "Fred", "Editable": "Hello" },
];
