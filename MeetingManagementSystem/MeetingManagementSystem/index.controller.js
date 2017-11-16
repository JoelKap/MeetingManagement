(function () {
    'use strict';

    function indexController($location, $scope, $rootScope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'index';
        $scope.isHome = true;
        $scope.isNewMeeting = false;
        $scope.isUpdateMeeting = false;
        $scope.hideDiv = true;
        $scope.isActive = false;


        $scope.navigateToHome = function (url) {
            $scope.isHome = true;
            $scope.isNewMeeting = false;
            $scope.isUpdateMeeting = false;
            $location.path(url);
        }

        $scope.navigateToMeeting = function (url) {
            $scope.isHome = false;
            $scope.isNewMeeting = true;
            $scope.isUpdateMeeting = false;
            $location.path(url);
        }

        $scope.navigateToUpate = function (url) {
            $scope.isHome = false;
            $scope.isNewMeeting = false;
            $scope.isUpdateMeeting = true;
            $location.path(url);
        }


    }

    angular.module('MEET').controller('indexController', indexController);
    indexController.$inject = ['$location', '$scope', '$rootScope'];
})();
