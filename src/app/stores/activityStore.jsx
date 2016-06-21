import {EventEmitter} from 'events';
import dispatcher from '../dispatcher';

var $ = require('jquery');

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
        $.ajax({
            url: baseUrl + '/Trip/224',
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.selectedActivity = data;
                this.emit("activityLoaded");
            }.bind(this),
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.error(baseUrl + 'diaryitems', textStatus, errorThrown.toString());
            }
        });
    }

    loadActivities() {
        $.ajax({
            url: baseUrl + '/diaryitems',
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.recentActivities = data;
                this._Loading = false;
                this.emit("change");
            }.bind(this),
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.error(baseUrl + 'diaryitems', textStatus, errorThrown.toString());
            }
        });
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