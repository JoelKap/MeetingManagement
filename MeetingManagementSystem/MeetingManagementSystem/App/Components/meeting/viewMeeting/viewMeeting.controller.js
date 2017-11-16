(function () {
    'use strict';

    function viewMeetingController($location, meetingService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'viewMeeting';
        vm.meeting = {};
        vm.date = "";
        vm.time = "";

        init();

        function init() {
            vm.meeting = meetingService.getSavedMeeting();
            if (vm.meeting.MeetingName == undefined) {
                $location.path('/home');
            }
            var strDate = vm.meeting.MeetingDate.toString();
            vm.date = strDate.substring(0, 15);

            var strTime = vm.meeting.MeetingTime.toString();
            vm.time = strTime.substring(24,16);
        }
    }

    angular.module('MEET').controller('viewMeetingController', viewMeetingController);
    viewMeetingController.$inject = ['$location', 'meetingService'];
})();
