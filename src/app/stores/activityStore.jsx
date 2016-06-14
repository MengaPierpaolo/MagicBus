import {EventEmitter} from 'events';

import dispatcher from '../dispatcher';

class ActivityStore extends EventEmitter {
    constructor(){
        super()
        this.activities =
        [
            { id: 1, experienceType: 'Sight', experience: 'You saw baboons in Milan' },
            { id: 2, experienceType: 'Trip', experience: 'You went from Paris to Milan' },
            { id: 3, experienceType: 'Chow', experience: 'You consumed pizza in Milan' }
        ];
    }

    createActivity(){
        this.activities.push({
            id: 4,
            experienceType: "Chow",
            experience: "Woohoo"
        });

        this.emit("change");
    }

    getAll() {
        return this.activities;
    }

    handleActions(action) {
        switch(action.type) {
            case 'ADD_ACTIVITY': {
                this.createActivity();
            }
        }
    }
}

const activityStore = new ActivityStore;
dispatcher.register(activityStore.handleActions.bind(activityStore));
export default activityStore;