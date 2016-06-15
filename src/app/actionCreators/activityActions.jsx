import dispatcher from '../dispatcher';

var $ = require('jquery');

export function loadActivities() {
    dispatcher.dispatch({
        type: "LOADING_ACTIVITIES"
    });

    dispatcher.dispatch({
        type: "LOAD_ACTIVITIES"
    })
}

export function addActivity() {
    dispatcher.dispatch({
        type: 'ADD_ACTIVITY'
    })
}

export function deleteActivity(id) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:8002/api/trip/' + encodeURIComponent(id) + '/',
        success: function () {
            dispatcher.dispatch({
                type: 'DELETED_ACTIVITY'
            });
        }.bind(this)
    });
}