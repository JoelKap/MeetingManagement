using MeetingManagementSystem.Interface;
using System;
using System.Collections.Generic;
using MeetingManagementSystem.Models;
using MeetingManagementSystem.DAL;

namespace MeetingManagementSystem.Services
{
    public class MeetingServiceProvider : IMeetingServiceProvider
    {

        public bool CreateMeeting(MeetingModel meeting)
        {
            try
            {
                return MeetingDAL.CreateMeeting(meeting);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MeetingItemModel> GetMeetingItemsByMeetingTypeId(Guid meetingTyeId, Guid meetingId)
        {
            try
            {
                return MeetingDAL.GetMeetingItemsByMeetingTypeId(meetingTyeId, meetingId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MeetingModel> GetMeetings()
        {
            try
            {
                return MeetingDAL.GetMeetings();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MeetingTypeModel> GetMeetingTypes()
        {
            try
            {
                return MeetingDAL.GetMeetingTypes();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MeetingTypeModel> GetMeetingTypesByMeetingId(Guid meetingId)
        {
            try
            {
                return MeetingDAL.GetMeetingTypesByMeetingId(meetingId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<StatusModel> GetStatuses()
        {
            try
            {
                return MeetingDAL.GetStatuses();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool updateMeetingItemStatus(MeetingModel updateMeetingItemStatus)
        {
            try
            {
                return MeetingDAL.UpdateMeetingItemStatus(updateMeetingItemStatus);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}