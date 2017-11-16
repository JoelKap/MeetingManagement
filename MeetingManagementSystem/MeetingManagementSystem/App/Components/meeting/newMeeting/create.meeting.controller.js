(function () {
    'use strict';

    function createController($location, meetingService, toastr) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'create';
        vm.available = {};
        vm.display = {};
        vm.selectedclients = {};
        vm.meetingTypes = [];
        vm.meetingType = {};
        vm.meetingItems = [];
        vm.meetings = [];
        vm.assignedMeetingItems = [];
        vm.isMeetingItemSelected = false;
        vm.isMeetingSelected = false;
        vm.meeting = {};
        init();

        function init() {
            meetingService.getMeetings(function (meetings) {
                vm.meetings = meetings
            })
        }

        vm.selectedMeeting = function (meeting) {
            vm.meeting = meeting;
            meetingService.getMeetingTypesByMeetingId(meeting.MeetingId, function (meetingTypes) {
                vm.meetingTypes = meetingTypes;
                vm.isMeetingSelected = true;
            })
        }

        vm.selectedMeetingType = function (meetingType) {
            vm.meetingType = meetingType;
            meetingService.getMeetingItems(meetingType.MeetingTypeId, vm.meeting.MeetingId, function (meetingItems) {
                vm.meetingItems = meetingItems;
                vm.isMeetingItemSelected = true;
            })
        }

        vm.moveItem = function (items, from, to) {
            items.forEach(function (item) {
                var idx = from.indexOf(item);
                if (idx != -1) {
                    from.splice(idx, 1);
                    to.push(item);
                    vm.assignedMeetingItems.push(item);
                }
            });
        };
        vm.selectedMeetingItem = function (meetingItem) {
            vm.display = {
                name: meetingItem[0].MeetingItemName,
                statusName: meetingItem[0].MeetingItemStatusName
            }
        }
        vm.moveAll = function (from, to) {
            angular.forEach(from, function (item) {
                to.push(item);
                vm.assignedMeetingItems.push(item);
            });
            from.length = 0;
        };

        vm.selectedclients = [];

        vm.createMeeting = function () {
            if (userIsValid()) {
                //Create meeting OBJ
                vm.meeting = {
                    MeetingTypeName: vm.meetingType.MeetingTypeName,
                    MeetingTypeId: vm.meetingType.MeetingTypeId,
                    MeetingDate: vm.meeting.meetingDate,
                    MeetingTime: vm.meeting.meetingTime,
                    MeetingItems: vm.assignedMeetingItems,
                    MeetingName: vm.meeting.meetingName
                }

                meetingService.createMeeting(vm.meeting, function (response) {
                    if (response) {
                        meetingService.saveMeeting(vm.meeting);
                        toastr.info('meeting has been created');
                        $location.path('/viewMeeting');
                    } else {
                        toastr.error('meeting not created, please try again... or contact administrator');
                    }
                })
            }
        }

        function userIsValid() {
            var isValid = true;
            if (vm.meeting.meetingName == undefined || vm.meeting.meetingName == "") {
                toastr.error('Please capture meeting name');
               return isValid = false;
            }
            if (vm.meeting.meetingDate == undefined || vm.meeting.meetingDate == "") {
                toastr.error('Please capture date');
                return isValid = false;
            }
            if (vm.meeting.meetingTime == undefined || vm.meeting.meetingTime == "") {
                toastr.error('Please capture time');
                return isValid = false;
            }
            if (vm.selectedclients.length < 1) {
                toastr.error('Please select meeting items');
                return isValid = false;
            }
            else {
              return isValid;
            }
        }
    }

    angular.module('MEET').controller('createController', createController);
    createController.$inject = ['$location', 'meetingService', 'toastr'];
})();
