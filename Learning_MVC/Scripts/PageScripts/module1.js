(function(){
    var app = angular.module("module1", ["module2", "module3"]);

    app.controller("controller1", function ($scope, module2Service, module3Factory) {
        $scope.message1 = "Greeting from Module 1";
        $scope.message2 = module2Service.GetMessage();
        $scope.message3 = module3Factory.GetMessage();
    })
}
)();