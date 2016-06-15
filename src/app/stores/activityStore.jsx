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
            url: 'http://localhost:8002/api/diaryitem',
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.activities = data;
                this._Loading = false;
                this.emit("change");
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('http://localhost:8002/api/diaryitem', status, err.toString());
            }.bind(this)
        });
    }

    handleActions(action) {
        switch (action.type) {
            case 'ADD_ACTIVITY': {
                this.createActivity();
            }
            case 'LOADING_ACTIVITIES': {
                this._Loading = true;
                this.emit("change");
            }
            case 'LOAD_ACTIVITIES': {
                this.loadActivities();
            }
            case 'DELETED_ACTIVITY': {
                this.loadActivities();
            }
            case 'ADDED_CHOW': {
                this.loadActivities();
            }
        }
    }
}

const activityStore = new ActivityStore;
dispatcher.register(activityStore.handleActions.bind(activityStore));
export default activityStore;