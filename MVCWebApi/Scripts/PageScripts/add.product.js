$(document).ready(function () {
    $("#addProduct").on("click", function () {
        $.post("http://localhost:55467/api/Product",
            $("#addProductForm").serialize());
    });
});