import dispatcher from '../dispatcher';
import * as ChowActions from '../actionCreators/ChowActions';

export function loadActivities() {
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_BEGIN" });
    dispatcher.dispatch({ type: "LOAD_ACTIVITIES_END" })
}

export function addActivity() {
    dispatcher.dispatch({ type: 'ADD_ACTIVITY' })
}

export function deleteActivity(type, id) {
    switch (type) {
        case 'Chow': {
            ChowActions.deleteChow(id);
            dispatcher.dispatch({ type: 'DELETE_CHOW' })
        }
    }
}
