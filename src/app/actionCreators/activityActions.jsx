import dispatcher from '../dispatcher';
import * as axios from 'axios';

export function loadActivities() {
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_BEGIN" });
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_END" });
}

export function loadActivity() {
    dispatcher.dispatch({ type: "LOAD_ACTIVITY_BEGIN" });
    dispatcher.dispatch({ type: "LOAD_ACTIVITY_END" });
}

export function addActivity() {
    dispatcher.dispatch({ type: 'ADD_ACTIVITY' })
}

export function saveActivity(type, item) {
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

export function deleteActivity(type, id) {
    axios.delete(baseUrl + '/' + type + '/' + encodeURIComponent(id))
        .then(function (response) {
            dispatcher.dispatch({ type: 'DELETE_ACTIVITY' });
        })
        .catch(function (error) {
            console.log(error);
        });
}