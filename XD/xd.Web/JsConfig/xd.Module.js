
//var xdApp = angular.module("xdApp", []);


(function () {
    var app = angular.module("app", []);
    //app.run(["$rootScope", function ($rootScope) {
    //    $rootScope.RootUrl = window.RootUrl
    //}]);
    app.controller("HomeController", function ($scope) {
        $scope.message = "mike"
    });
});