import { Injectable } from '@angular/core';
import { ActivityViewModel } from '../viewModel/activityViewModel'
import { Trip } from '../model/Trip'
import { Chow } from '../model/Chow'
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class DataService {
    constructor(private http: Http) { }

    private baseUrl = 'http://localhost:5050/api';

    getRecentExperiences(): Observable<ActivityViewModel[]> {
        return this.http.get(this.baseUrl + '/experiences')
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

    // getActivity(type: string, id: number)
    // {
    //     switch (type) {
    //         case 'trip':
    //             return this.getTrip(id);
    //         case 'chow':
    //             return this.getChow(id);
    //         case 'sight':
    //             return this.getSight(id);
    //         case 'nap':
    //             return this.getTrip(id);
    //         default:
    //             break;
    //     }
    // }

    getActivity(type : string, id: number): Observable<any> {
        return this.http.get(this.baseUrl + '/' + type + '/' + id)
            .map(this.extractData)
            .catch(this.handleError);
    }
}