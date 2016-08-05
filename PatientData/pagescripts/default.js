$(document).ready(function () {

    var getPatients = function () {
        //$.get(url).always(showResponse);
        var url = 'http://localhost:38885/api/patients/';
        $.ajax(url, {
            type: 'GET',
            header: getHeaders()
        }).always(showResponse);

        return false;
    };

    var getHeaders = function () {
        if (accessToken) {
            alert('Bearer ' + accessToken);
            return { 'Authorization': 'Bearer ' + accessToken };
        }
    };

    var showResponse = function (object) {
        $('#output').text(JSON.stringify(object, null, 4));
    };

    var register = function () {
        var url = "/api/account/register"
        var data = $('#userData').serialize();
        $.post(url, data).always(showResponse);
        return false;
    };

    var accessToken = '';
    var saveAccessToken = function (data) {
        accessToken = data.access_token;
    };

    var login = function () {
        var url = "/Token"
        var data = $('#userLogin').serialize();
        data = data + '&grant_type=password'
        $.post(url, data)
            .always(showResponse)
            .success(saveAccessToken);
        return false;
    };
    
    $('#getPatients').click(getPatients);
    $('#register').click(register);
    $('#login').click(login);
})