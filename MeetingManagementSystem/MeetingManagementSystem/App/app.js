(function () {
    'use strict';

    var app = angular.module('MEET', ['ngRoute', 'ngStorage', 'angular-loading-bar', 'toastr']);
    app.constant('baseUrl', 'api');

    app.run(function ($rootScope, $location, $sessionStorage, $timeout) {
        $rootScope.$on('$routeChangeSuccess', function () {
            $rootScope.currentUrl = $location.path();
        });
    });

}());