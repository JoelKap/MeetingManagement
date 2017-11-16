(function () {
    'use strict';

    function homeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'home';

        vm.navigateTo = function (url) {
            $location.path(url);
        }
    }

    angular.module('MEET').controller('homeController', homeController);
    homeController.$inject = ['$location'];
})();
