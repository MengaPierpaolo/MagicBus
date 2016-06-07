import { Injectable } from '@angular/core';
import { ActivityViewModel } from '../model/activityViewModel'

@Injectable()
export class DataService {
    getRecentExperiences() : ActivityViewModel[] {
        return STUFF;
    }
}

var STUFF: ActivityViewModel[] = [
  { "ExperienceType" : "Trip", "Experience": "You saw monkeys in Brighton" },
  { "ExperienceType" : "Trip", "Experience": "You consumed cake in Seoul" },
  { "ExperienceType" : "Trip", "Experience": "You saw rare birds in Nagoya" },
  { "ExperienceType" : "Trip", "Experience": "You went from Nagoya to Seoul by plane" }
];
