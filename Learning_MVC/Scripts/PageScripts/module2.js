(function () {
    var app = angular.module("module2", [])

    app.service("module2Service", function () {
        this.GetMessage = function () {
            return "Greeting from Module 2";
        };
    })
})();