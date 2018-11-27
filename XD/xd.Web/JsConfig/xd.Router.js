
angular.module("eduqApp")
    .config([
        "$stateProvider", "$urlRouterProvider", "$httpProvider",
        function ($stateProvider, $urlRouterProvider, $httpProvider) {

            $httpProvider.interceptors.push("httpLoader");
            $urlRouterProvider.otherwise("/Home");

            var states = [
                eduq.Routes.SetRoutes("Home", "Home"),
                eduq.Routes.SetRoutes("Entity", "Create"),
                eduq.Routes.SetRoutes("Entity", "Read"),
                eduq.Routes.SetRoutes("Entity", "Update"),
                eduq.Routes.SetRoutes("Field", "Create"),
                eduq.Routes.SetRoutes("Field", "Read"),
                eduq.Routes.SetRoutes("Field", "Update"),
                eduq.Routes.SetRoutes("View", "Create"),
                eduq.Routes.SetRoutes("View", "Read"),
                eduq.Routes.SetRoutes("View", "Update"),
                eduq.Routes.SetRoutes("xEntity", "Create"),
                eduq.Routes.SetRoutes("xEntity", "Read"),
                eduq.Routes.SetRoutes("xEntity", "Update"),
            ];

            states.forEach(function (state) {
                $stateProvider.state(state);
            });

        }
    ]);
