(function () {
    'use strict';

    function updateMeetingController($location, meetingService, $route, toastr) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'update';
        vm.meetings = [];
        vm.meetingItems = [];
        vm.assignedMeetingItems = [];
        vm.selectedclients = [];
        vm.meetingTypes = [];
        vm.isMeetingItemSelected = false;
        vm.isStatusSelected = false;
        vm.updatStatus = false;
        vm.isMeetingSelected = false;
        vm.available = {};
        vm.meeting = {};
        vm.status = {};
        init();

        function init() {
            meetingService.getMeetings(function (meetings) {
                vm.meetings = meetings
            })
            meetingService.getStatuses(function (statuses) {
                vm.statuses = statuses;
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



        vm.selectedStatus = function (status) {
            vm.status = status;
            vm.isStatusSelected = true;
        }

        vm.updateSelectedItem = function (meetingItem) {
            vm.updatStatus = true;
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
                statusName: meetingItem[0].MeetingItemStatusName,
                personAssigned: meetingItem[0].PersonAssigned,
            }
        }
        vm.moveAll = function (from, to) {
            angular.forEach(from, function (item) {
                to.push(item);
                vm.assignedMeetingItems.push(item);
            });
            from.length = 0;
        };


        vm.saveMeetingItemStatus = function () {
            vm.meeting.MeetingItems = vm.meetingItems;
            vm.meeting.MeetingItems[0].MeetingItemStatusId = vm.status.StatusId;
            meetingService.updateMeetingStatus(vm.meeting, function (response) {
                if (response) {
                    toastr.info('Meeting was saved');
                    $route.reload();
                } else {
                    toastr.info('Meeting was not saved');
                }
            })
        }
    }

    angular.module('MEET').controller('updateMeetingController', updateMeetingController);
    updateMeetingController.$inject = ['$location', 'meetingService', '$route', 'toastr'];
})();
