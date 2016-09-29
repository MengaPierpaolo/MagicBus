import dispatcher from '../dispatcher';
import * as axios from 'axios';

export function loadActivities() {
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_BEGIN" });
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_END" });
}

export function loadActivity(activityId) {
    dispatcher.dispatch({ type: "LOAD_ACTIVITY_BEGIN" });
    dispatcher.dispatch({ type: "LOAD_ACTIVITY_END", data: { activityId: activityId } });
}

export function addActivity() {
    dispatcher.dispatch({ type: 'ADD_ACTIVITY' })
}

export function saveActivity(type, item, id) {
    var baseUrl = 'http://localhost:5050/api';
    if (id > 0) {
        axios.put(
            baseUrl + '/' + type + '/' + id,
            JSON.stringify(item),
            { headers: { 'Content-Type': 'application/json' } }
        )
            .then(function (response) {
                dispatcher.dispatch({ type: 'ADD_ACTIVITY' });
            })
            .catch(function (error) {
                console.log(error);
            });

    }
    else {
        axios.post(
            baseUrl + '/' + type,
            JSON.stringify(item),
            { headers: { 'Content-Type': 'application/json' } }
        )
            .then(function (response) {
                dispatcher.dispatch({ type: 'ADD_ACTIVITY' });
            })
            .catch(function (error) {
                console.log(error);
            });
    }
}
export function deleteActivity(type, id) {
    var baseUrl = 'http://localhost:5050/api';

    axios.delete(baseUrl + '/' + type + '/' + encodeURIComponent(id))
        .then(function (response) {
            dispatcher.dispatch({ type: 'DELETE_ACTIVITY' });
        })
        .catch(function (error) {
            console.log(error);
        });
}