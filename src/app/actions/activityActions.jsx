import dispatcher from '../dispatcher';

export function addActivity() {
    dispatcher.dispatch({
        type: 'ADD_ACTIVITY'
    })
}

export function reloadActivities() {
    dispatcher.dispatch({
        type: "RELOAD_ACTIVITIES"
    })
}