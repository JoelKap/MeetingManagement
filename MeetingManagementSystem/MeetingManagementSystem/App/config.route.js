(function () {

    'use strict';




    var routeProvider = function ($routeProvider) {

        var viewBase = '/App/Components/';

        $routeProvider.when('/newMeeting', {
            controller: 'createController',
            templateUrl: viewBase + 'meeting/newMeeting/create.meeting.html',
            controllerAs: 'vm'
        })
            .when('/updateMeeting', {
                controller: 'updateMeetingController',
                templateUrl: viewBase + 'meeting/existingMeeting/update.meeting.html',
                controllerAs: 'vm'
            })
            .when('/viewMeeting', {
                controller: 'viewMeetingController',
                templateUrl: viewBase + 'meeting/viewMeeting/viewMeeting.html',
                controllerAs: 'vm'
            })
            .when('/home', {
                controller: 'homeController',
                templateUrl: viewBase + 'home/home.html',
                controllerAs: 'vm'
            })

            .otherwise({
                redirectTo: '/home'
            });
    }
    angular.module('MEET').config(['$routeProvider', routeProvider]);
    routeProvider.$inject = ['$routeProvider', ];
}());
