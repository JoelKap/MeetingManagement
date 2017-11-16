(function () {
    'use strict';
    
    function meetingFactory($http, $q, baseUrl) {


        var getMeetingItems = function (meetingTypeId, meetingId) {
            var defered = $q.defer();

            var meetingItemsComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.get(baseUrl + '/Meeting/GetMeetingTypeItem/?meetingTypeId=' + meetingTypeId + '&meetingId=' + meetingId).then(meetingItemsComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;
        }

        var getMeetingTypesByMeetingId = function (meetingId) {
            var defered = $q.defer();

            var meetingTypesComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.get(baseUrl + '/Meeting/GetMeetingTypesByMeetingId/?meetingId=' + meetingId).then(meetingTypesComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;
        }

        var getMeetingTypes = function () {
            var defered = $q.defer();

            var meetingTypesComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.get(baseUrl + '/Meeting/GetMeetingTypes').then(meetingTypesComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;
        }

        var getMeetings = function () {
            var defered = $q.defer();

            var meetingsComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.get(baseUrl + '/Meeting/GetMeetings').then(meetingsComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;//getMeetings
        }


        var createMeeting = function (meeting) {
            var defered = $q.defer();

            var createMeetingComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.post(baseUrl + '/Meeting/CreateMeeting', meeting).then(createMeetingComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;
        }

        var getStatuses = function () {
            var defered = $q.defer();

            var getStatusesComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.get(baseUrl + '/Meeting/GetStatuses').then(getStatusesComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;
        }

        var updateMeetingStatus = function (meeting) {
            var defered = $q.defer();

            var updateMeetingItemStatusComplete = function (response) {
                defered.resolve(response.data);
            }

            $http.put(baseUrl + '/Meeting/UpateMeetingItemStatus', meeting).then(updateMeetingItemStatusComplete, function (err, status) {
                defered.reject(err);
            });
            return defered.promise;
        }

        return {
            createMeeting: createMeeting,
            getMeetingTypes: getMeetingTypes,
            getMeetingItems: getMeetingItems,
            getMeetings: getMeetings,
            getStatuses:getStatuses,
            updateMeetingStatus: updateMeetingStatus,
            getMeetingTypesByMeetingId: getMeetingTypesByMeetingId
        }

    }

    angular.module('MEET').factory('meetingFactory', meetingFactory);
    meetingFactory.$inject = ['$http', '$q', 'baseUrl'];
})();