(function () {
    var app = angular.module("module3", []);

    app.factory("module3Factory", function () {
        var func = {};

        func.GetMessage = function () {
            return "Greeting from Module 3";
        };

        return func;
    })
})();