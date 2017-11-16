(function () {
    'use strict';

    function meetingService(meetingFactory) {
        var self = this;
        self.meetingItems = [];
        self.meetingTypes = [];
        self.meeting = {};

        this.createMeeting = function (meeting, callback) {
            meetingFactory.createMeeting(meeting).then(function (response) {
                callback(response);
            });
        }

        this.getMeetingTypes = function (callback) {
            meetingFactory.getMeetingTypes().then(function (meetingTypes) {
                callback(meetingTypes);
            });
        }

        this.getMeetingItems = function (meetingTypeId, meetingId, callback) {
            meetingFactory.getMeetingItems(meetingTypeId, meetingId).then(function (meetingItems) {
                callback(meetingItems);
            })
        }

        this.getMeetingTypesByMeetingId = function (meetingId, callback) {
            meetingFactory.getMeetingTypesByMeetingId(meetingId).then(function (meetingTypes) {
                callback(meetingTypes);
            })
        }

        this.getMeetings = function (callback) {
            meetingFactory.getMeetings().then(function (meetings) {
                callback(meetings);
            });
        }

        this.getStatuses = function (callback) {
            meetingFactory.getStatuses().then(function (statuses) {
                callback(statuses);
            });
        }

        this.updateMeetingStatus = function (meeting, callback) {
            meetingFactory.updateMeetingStatus(meeting).then(function (response) {
                callback(response);
            });
        }

        this.saveMeeting = function (meeting) {
            self.meeting = meeting;
        }
        
        this.getSavedMeeting = function () {
            return self.meeting;
        }
    }

    angular.module('MEET').service('meetingService', meetingService);
    meetingService.$inject = ['meetingFactory'];
})();