import { Injectable } from '@angular/core';
import { ActivityViewModel } from '../viewModel/activityViewModel'

@Injectable()
export class DataService {
    getRecentExperiences() : ActivityViewModel[] {
        return STUFF;
    }
}

var STUFF: ActivityViewModel[] = [
  { "ExperienceType" : "sight", "Experience": "You saw monkeys in Brighton" },
  { "ExperienceType" : "chow", "Experience": "You consumed cake in Seoul" },
  { "ExperienceType" : "sight", "Experience": "You saw rare birds in Nagoya" },
  { "ExperienceType" : "trip", "Experience": "You went from Nagoya to Seoul by plane" },
  { "ExperienceType" : "nap", "Experience": "You dozed in a hammock in Gibraltar" }
];
