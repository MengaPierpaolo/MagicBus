import dispatcher from '../dispatcher';

var $ = require('jquery');

export function loadActivities() {
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_BEGIN" });
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_END" })
}

export function addActivity() {
    dispatcher.dispatch({ type: 'ADD_ACTIVITY' })
}

export function saveActivity(type, item) {
    $.ajax({
        type: 'POST',
        url: baseUrl + '/' + type,
        headers: { 'Content-Type': 'application/json' },
        data: JSON.stringify(item),
        success: function () {
            dispatcher.dispatch({ type: 'ADD_ACTIVITY' });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.error(baseUrl + '/' + type, textStatus, errorThrown.toString());
        }
    });
}

export function deleteActivity(type, id) {
    $.ajax({
        type: 'DELETE',
        url: baseUrl + '/' + type + '/' + encodeURIComponent(id),
        success: function () {
            dispatcher.dispatch({ type: 'DELETE_ACTIVITY' });
        }
    });
}