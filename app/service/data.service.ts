import { Injectable } from '@angular/core';
import { ActivityViewModel } from '../viewModel/activityViewModel'


var STUFF: ActivityViewModel[] = [
    { "Id": 2, "ExperienceType": "chow", "Experience": "You consumed cake in Seoul" },
    { "Id": 3, "ExperienceType": "sight", "Experience": "You saw rare birds in Nagoya" },
    { "Id": 4, "ExperienceType": "trip", "Experience": "You went from Nagoya to Seoul by plane" },
    { "Id": 5, "ExperienceType": "nap", "Experience": "You dozed in a hammock in Gibraltar" }
];

let stuffPromise = Promise.resolve(STUFF);

@Injectable()
export class DataService {
    getRecentExperiences() {
        return stuffPromise;
    }

    getTrip(id: number) {
        return stuffPromise
            .then(item => item.filter(c => c.Id === +id)[0]);
    }
}