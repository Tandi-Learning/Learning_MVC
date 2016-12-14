$(document).ready(function () {
    $('#createButton').on("click", function () {
        $.post('http://localhost:55467/api/Product',
            {
                CategoryName: $('#CategoryName').val(),
                Name: $('#Name').val(),
                Price: $('Price').val(),
            })
        .success(function (data) {            
        })
        .fail(function (jqXHR, status, error) {
        })
    })
});