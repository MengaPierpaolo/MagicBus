import {EventEmitter} from 'events';
import dispatcher from '../dispatcher';
import * as axios from 'axios';

class ActivityStore extends EventEmitter {
    constructor() {
        super()
        this.recentActivities = [];
        this.selectedActivity = {};
        this._Loading = false;
    }

    isLoading() {
        return this._Loading;
    }

    getRecentActivities() {
        return this.recentActivities;
    }

    getSelectedActivity() {
        return this.selectedActivity;
    }

    loadActivity(activityId) {
        let store = this;
        axios.get(baseUrl + '/Trip/224')
            .then(function (response) {
                store.selectedActivity = response.data;
                store.emit("activityLoaded");
            })
            .catch(function (error) {
                console.log(error)
            });
    }

    loadActivities() {
        let store = this;
        this.recentActivities = axios.get(baseUrl + '/diaryitems')
            .then(function (response) {
                store.recentActivities = response.data;
                store._Loading = false;
                store.emit("change");
            })
            .catch(function (error) {
                console.log(error)
            })
    }

    handleActions(action) {
        switch (action.type) {
            case 'LOAD_ACTIVITIES_BEGIN': {
                this._Loading = true;
                this.emit("change");
                break;
            }
            case 'LOAD_ACTIVITIES_END':
            case 'ADD_ACTIVITY':
            case 'DELETE_ACTIVITY':
                this.loadActivities();
                break;
            case 'LOAD_ACTIVITY_BEGIN':
                this.loading = true;
                this.emit("change");
                break;
            case 'LOAD_ACTIVITY_END':
                this.loadActivity(208);
                this.emit("change");
                break;
        }
    }
}

const activityStore = new ActivityStore;
dispatcher.register(activityStore.handleActions.bind(activityStore));
export default activityStore;