//xdApp.controller("HomeController", ["$scope", "viewModel",
//    function ($scope, viewModel) {
//        $scope.viewModel = viewModel;
//        debugger;
//    }]
//);


(function () {
    angular.module("app")
        .controller("HomeController", HomeController);
    HomeController.$inject = ["$scope"];
    function HomeController($scope) {
        debugger;
    }
});