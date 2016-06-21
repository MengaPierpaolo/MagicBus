import {EventEmitter} from 'events';
import dispatcher from '../dispatcher';

var $ = require('jquery');

class ActivityStore extends EventEmitter {
    constructor() {
        super()
        this.activities = [];
        this._Loading = false;
    }

    isLoading() {
        return this._Loading;
    }

    getAll() {
        return this.activities;
    }

    loadActivities() {
        $.ajax({
            url: baseUrl + '/diaryitems',
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.activities = data;
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
            case 'LOAD_ACTIVITIES_END': {
                this.loadActivities();
                break;
            }
            case 'DELETE_ACTIVITY': {
                this.loadActivities();
                break;
            }
            case 'ADD_CHOW': {
                this.loadActivities();
                break;
            }
        }
    }
}

const activityStore = new ActivityStore;
dispatcher.register(activityStore.handleActions.bind(activityStore));
export default activityStore;