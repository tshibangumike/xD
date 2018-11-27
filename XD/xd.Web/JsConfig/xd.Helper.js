﻿if (typeof (eduq) == "undefined") {
    eduq = {};
};

eduq.Routes = {
    GetSideMenuRouteView: function () {
        return {
            templateUrl: "/Components/Sidemenu/Sidemenu.html",
            controller: "SideMenuController",
            resolve: {
                sideMenuItems: [
                    "$stateParams", "appService", function ($stateParams, appService) {
                        return appService.GetData("/SideMenu/GetSideMenuItems");
                    }
                ]
            }
        };
    },
    GetToolbarRouteView: function () {
        return {
            templateUrl: "/Components/Toolbar/Toolbar.html",
            controller: "ToolbarController",
            resolve: {}
        };
    },
    GetBaseRouteView: function () {
        return {
            templateUrl: "/Components/Base/Base.html",
            controller: "BaseController",
            resolve: {}
        };
    },
    SetRoutes: function () {

        if (arguments.length === 0) return null;

        var entityName = arguments[0] == null ? null : arguments[0];
        var routeName = arguments[1] == null ? null : arguments[1];

        switch (entityName) {
            case "Home":
                return {
                    name: "Home",
                    url: "/Home",
                    views: {
                        "": eduq.Routes.GetBaseRouteView(),
                        "toolbar@Home": eduq.Routes.GetToolbarRouteView(),
                        "sidemenu@Home": eduq.Routes.GetSideMenuRouteView(),
                        "body@Home": {
                            templateUrl: "/Components/Home/Home.html",
                            controller: "HomeController"
                        }
                    }
                };
            case "Entity":
                switch (routeName) {
                    case "Create":
                        return {
                            name: "createentity",
                            url: "/createentity",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@createentity": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@createentity": eduq.Routes.GetSideMenuRouteView(),
                                "body@createentity": {
                                    templateUrl: "/Components/Entity/CreateEntity.html",
                                    controller: "CreateEntityController",
                                    resolve: {
                                    }
                                }
                            }
                        };
                    case "Read":
                        return {
                            name: "readentities",
                            url: "/readentities",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@readentities": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@readentities": eduq.Routes.GetSideMenuRouteView(),
                                "body@readentities": {
                                    templateUrl: "/Components/Entity/ReadEntities.html",
                                    controller: "ReadEntitiesController",
                                    resolve: {
                                        entities: [
                                            "appService", function (appService) {
                                                return appService.GetData("/Entity/GetEntities");
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    case "Update":
                        return {
                            name: "updateentity",
                            url: "/updateentity?entityid",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@updateentity": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@updateentity": eduq.Routes.GetSideMenuRouteView(),
                                "body@updateentity": {
                                    templateUrl: "/Components/Entity/UpdateEntity.html",
                                    controller: "UpdateEntityController",
                                    resolve: {
                                        entity: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return appService.GetData("/Entity/GetEntityById", { entityId: $stateParams.entityid });
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    default:
                        return null;
                }
            case "Field":
                switch (routeName) {
                    case "Create":
                        return {
                            name: "createfield",
                            url: "/createfield?entityid&entityname",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@createfield": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@createfield": eduq.Routes.GetSideMenuRouteView(),
                                "body@createfield": {
                                    templateUrl: "/Components/Field/CreateField.html",
                                    controller: "CreateFieldController",
                                    resolve: {
                                        entity: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return { Id: $stateParams.entityid, Name: $stateParams.entityname };
                                            }
                                        ],
                                        fieldTypes: [
                                            "appService", function (appService) {
                                                return appService.GetData("/FieldType/GetFieldTypes");
                                            }
                                        ],
                                        entities: [
                                            "appService", function (appService) {
                                                return appService.GetData("/Entity/GetEntities");
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    case "Read":
                        return {
                            name: "readfields",
                            url: "/readfields",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@readfields": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@readfields": eduq.Routes.GetSideMenuRouteView(),
                                "body@readfields": {
                                    templateUrl: "/Components/Field/ReadFields.html",
                                    controller: "ReadFieldsController",
                                    resolve: {
                                        fields: [
                                            "appService", function (appService) {
                                                return appService.GetData("/Field/GetFields");
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    case "Update":
                        return {
                            name: "updatefield",
                            url: "/updatefield?fieldid",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@updatefield": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@updatefield": eduq.Routes.GetSideMenuRouteView(),
                                "body@updatefield": {
                                    templateUrl: "/Components/Field/UpdateField.html",
                                    controller: "UpdateFieldController",
                                    resolve: {
                                        field: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return appService.GetData("/Field/GetFieldById", { fieldId: $stateParams.fieldid });
                                            }
                                        ],
                                        fieldTypes: [
                                            "appService", function (appService) {
                                                return appService.GetData("/FieldType/GetFieldTypes");
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    default:
                        return null;
                }
            case "View":
                switch (routeName) {
                    case "Create":
                        return {
                            name: "createview",
                            url: "/createview?entityid&entityname",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@createview": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@createview": eduq.Routes.GetSideMenuRouteView(),
                                "body@createview": {
                                    templateUrl: "/Components/View/CreateView.html",
                                    controller: "CreateViewController",
                                    resolve: {
                                        entity: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return { Id: $stateParams.entityid, Name: $stateParams.entityname };
                                            }
                                        ],
                                        fields: ["$stateParams", "appService", function ($stateParams, appService) {
                                            return   eduq.HttpQueries.Views.GetViewsByEntityId($scope, appService, $scope.entity.Id);
                                        }
                                        ]
                                    }
                                }
                            }
                        };
                    case "Read":
                        return {
                            name: "readviews",
                            url: "/readviews",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@readviews": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@readviews": eduq.Routes.GetSideMenuRouteView(),
                                "body@readviews": {
                                    templateUrl: "/Components/View/ReadViews.html",
                                    controller: "ReadViewsController",
                                    resolve: {
                                        views: [
                                            "appService", function (appService) {
                                                return appService.GetData("/View/GetViews");
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    case "Update":
                        return {
                            name: "updateview",
                            url: "/updateview?viewid",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@updateview": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@updateview": eduq.Routes.GetSideMenuRouteView(),
                                "body@updateview": {
                                    templateUrl: "/Components/View/UpdateView.html",
                                    controller: "UpdateViewController",
                                    resolve: {
                                        view: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return appService.GetData("/View/GetViewById", { viewId: $stateParams.viewid });
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    default:
                        return null;
                }
            case "xEntity":
                switch (routeName) {
                    case "Create":
                        return {
                            name: "createrecord",
                            url: "/createrecord",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@createrecord": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@createrecord": eduq.Routes.GetSideMenuRouteView(),
                                "body@createrecord": {
                                    templateUrl: "/Components/xEntity/CreatexEntity.html",
                                    controller: "CreatexRecordController",
                                    resolve: {
                                    }
                                }
                            }
                        };
                    case "Read":
                        return {
                            name: "readrecords",
                            url: "/readrecords?entityid&viewid",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@readrecords": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@readrecords": eduq.Routes.GetSideMenuRouteView(),
                                "body@readrecords": {
                                    templateUrl: "/Components/xEntity/ReadxEntities.html",
                                    controller: "ReadxRecordsController",
                                    resolve: {
                                        routeData: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return { entityId: $stateParams.entityid, viewId: $stateParams.viewid };
                                            }
                                        ],
                                        views: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return appService.GetData("/View/GetViewsByEntityId", { entityId: $stateParams.entityid });
                                            }
                                        ],
                                        records: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return appService.GetData("/xEntity/GetxEntityRecords", { viewId: $stateParams.viewid });
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    case "Update":
                        return {
                            name: "updaterecord",
                            url: "/updaterecord?recordid",
                            views: {
                                "": eduq.Routes.GetBaseRouteView(),
                                "toolbar@updaterecord": eduq.Routes.GetToolbarRouteView(),
                                "sidemenu@updaterecord": eduq.Routes.GetSideMenuRouteView(),
                                "body@updaterecord": {
                                    templateUrl: "/Components/xEntity/UpdatexEntity.html",
                                    controller: "UpdatexRecordController",
                                    resolve: {
                                        record: [
                                            "$stateParams", "appService", function ($stateParams, appService) {
                                                return appService.GetData("/xEntity/GetxEntityRecordById", { recordId: $stateParams.recordid });
                                            }
                                        ]
                                    }
                                }
                            }
                        };
                    default:
                        return null;
                }
            default:
        }
        return null;

    }
};

eduq.Functions = {
    SplitObjectIntoArray: function () {
        if (arguments.length === 0) return null;
        var record = arguments[0] == null ? null : arguments[0];
        var keyValues = [];
        _.forEach(record, function (value, key) {
            if (key.indexOf("Time") > 0 || key.indexOf("Date") > 0 || key.indexOf("Day") > 0) {
                if (!_.isNull(value)) {
                    var values = value.split("/");
                    var day = values[0];
                    var month = values[1];
                    var yeartime = values[2].split(" ");
                    var year = yeartime[0];
                    var time = yeartime[1];
                    value = year + "-" + month + "-" + day + " " + time;
                    keyValues.push({ Key: key, Value: value });
                }
            } else {
                keyValues.push({ Key: key, Value: value });
            }
        });
        return keyValues;
    }
};

eduq.Loading = {
    Start: function (message) {
        if (message == null)
            return $("body").loading({
                message: "Opération en cours..."
            });
        else
            return $("body").loading({
                message: message
            });
    },
    Stop: function () {
        return $("body").loading("stop");
    }
};

eduq.Notifications = {
    Toastr: {
        SetToastrOption: function () {
            toastr.options = {
                "debug": false,
                "positionClass": "toast-top-center",
                "progressBar": true,
                "onclick": null,
                "fadeIn": 300,
                "fadeOut": 1000,
                "timeOut": 5000,
                "extendedTimeOut": 1000
            }
        },
        CreateSuccessNotification: function () {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.success("L'enregistrement a été creé avec succès!", "Confirmation");
        },
        ShowErrorNotification: function (message) {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.error("L'enregistrement n'a pas été sauvegardé avec success!", "Erreur");
        },
        CreateErrorNotification: function (message) {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.error("L'enregistrement n'a pas été sauvegardé avec success!", "Erreur");
        },
        UpdateSuccessNotification: function () {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.success("L'enregistrement a été modifié avec succès!", "Confirmation");
        },
        UpdateErrorNotification: function (message) {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.error("L'enregistrement n'a pas été modifié avec succès!", "Erreur");
        },
        DeleteSuccessNotification: function () {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.success("L'enregistrement a été supprimé avec succès!", "Confirmation");
        },
        DeleteErrorNotification: function (message) {
            eduq.Notifications.Toastr.SetToastrOption();
            toastr.error("L'enregistrement n'a pas été supprimé avec succès!", "Erreur");
        }
    },
    Notify: {
        CreateSuccessNotification: function () {
            $.notify(
                "L'enregistrement a sauvegardé avec success!",
                { position: "top center" }
            );
        },
        UpdateSuccessNotification: function () {
            $.notify(
                "L'enregistrement a modifié avec success!",
                { position: "top center" }
            );
        }
    }
};

eduq.HtmlBinding = {
    GetInputHtmlText: function () {

        if (arguments.length === 0) return null;
        var inputType = arguments[0] == null ? null : arguments[0];
        var cssClass = arguments[1] == null ? null : arguments[1];
        var inputName = arguments[2] == null ? null : arguments[2];
        var model = arguments[3] == null ? null : arguments[3];
        var isRequired = arguments[4] == null ? null : arguments[4];
        var classExpression = arguments[5] == null ? null : arguments[5];
        var isDisabled = arguments[6] == null ? null : arguments[6];

        return "<input type='" + inputType + "' class='" + cssClass + "' name='" + inputName + "' ng-model='" + model + "' ng-required='" + isRequired + "' ng-class='" + classExpression + "' />";

    }
};

eduq.HttpQueries = {
    Entity: {},
    Fields: {
        GetFieldsByEntityId: function (appService, entityId) {
            return appService.GetData("/Field/GetFieldsByEntityId", { entityId: entityId });
        },
        GetFieldsByViewId: function (appService, viewId) {
            return appService.GetData("/Field/GetFieldsByViewId", { viewId: viewId });
        }
    },
    Views: {
        GetViewsByEntityId: function (scope, appService, entityId) {
            appService.GetData("/View/GetViewsByEntityId", { entityId: entityId })
                .then(function successCallback(response) {
                    scope.views = response.data;
                }, function errorCallback(response) {
                });
        },
        GetDefaultViewByEntityId: function (appService, entityId) {
            return appService.GetData("/View/GetDefaultViewByEntityId", { entityId: entityId });
        }
    },
    Forms: {}
};
