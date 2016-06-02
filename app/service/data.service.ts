import { Injectable } from '@angular/core';
import { Activity } from '../model/activityViewModel'

@Injectable()
export class DataService {
    getRecentExperiences() : Activity[] {
        return STUFF;
    }
}

var STUFF: Activity[] = [
  { "Experience": "You saw monkeys in Brighton" },
  { "Experience": "You consumed cake in Seoul" },
  { "Experience": "You saw rare birds in Nagoya" },
  { "Experience": "You went from Nagoya to Seoul by plane" }
];
