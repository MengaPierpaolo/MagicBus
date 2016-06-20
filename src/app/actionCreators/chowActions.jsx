import dispatcher from '../dispatcher';
var $ = require('jquery');

export function saveChow(chow) {
    $.ajax({
        type: 'POST',
        url: baseUrl + '/chow',
        headers: { 'Content-Type': 'application/json' },
        data: JSON.stringify(chow),
        success: function () {
            dispatcher.dispatch({ type: 'ADD_CHOW' });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.error(baseUrl + 'diaryitems', textStatus, errorThrown.toString());
        }
    });
}

export function deleteChow(id) {
    $.ajax({
        type: 'DELETE',
        url: baseUrl + '/chow/' + encodeURIComponent(id),
        success: function () {
            dispatcher.dispatch({ type: 'DELETE_ACTIVITY' });
        }
    });
}