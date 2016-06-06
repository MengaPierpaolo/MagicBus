import { Injectable } from '@angular/core';
import { ActivityViewModel } from '../model/activityViewModel'

@Injectable()
export class DataService {
    getRecentExperiences() : ActivityViewModel[] {
        return STUFF;
    }
}

var STUFF: ActivityViewModel[] = [
  { "Experience": "You saw monkeys in Brighton" },
  { "Experience": "You consumed cake in Seoul" },
  { "Experience": "You saw rare birds in Nagoya" },
  { "Experience": "You went from Nagoya to Seoul by plane" }
];
