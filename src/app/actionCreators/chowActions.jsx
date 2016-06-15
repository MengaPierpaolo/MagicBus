import dispatcher from '../dispatcher';

var $ = require('jquery');

export function saveChow(chow) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:8002/api/trip/',
        data: { 'value': 'newcontact' },
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
	    dataType: 'json',
        success: function (data, status) {
            dispatcher.dispatch({ type: 'ADDED_CHOW' });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}