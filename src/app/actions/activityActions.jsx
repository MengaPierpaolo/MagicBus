import dispatcher from '../dispatcher';

export function addActivity() {
    dispatcher.dispatch({
        type: 'ADD_ACTIVITY'
    })
}