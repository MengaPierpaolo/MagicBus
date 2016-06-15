import {EventEmitter} from 'events';
import dispatcher from '../dispatcher';

var $ = require('jquery');

class ActivityStore extends EventEmitter {
    constructor() {
        super()
        this.activities = [];
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
            case 'RELOAD_ACTIVITIES': {
                this.loadActivities();
            }
            case 'DELETED_ACTIVITY': {
                this.loadActivities();
            }
        }
    }
}

const activityStore = new ActivityStore;
dispatcher.register(activityStore.handleActions.bind(activityStore));
export default activityStore;