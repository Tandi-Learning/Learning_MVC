$(document).ready(function () {

    var getPatients = function () {
        $.get(url).always(showResponse);
        return false;
    };

    var showResponse = function (object) {
        $('#output').text(JSON.stringify(object, null, 4));
    };

    var url = 'http://localhost:38885/api/patients/';
    $('#getPatients').click(getPatients);

    
})