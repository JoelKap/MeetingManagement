using MeetingManagementSystem.Interface;
using MeetingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeetingManagementSystem.Controllers
{
    public class MeetingController : ApiController
    {
        private IMeetingServiceProvider _meetingServiceProvider;

       
        public MeetingController(IMeetingServiceProvider meetingServiceProvider)
        {
            _meetingServiceProvider = meetingServiceProvider;
        }

        // GET: api/Meeting 
        public List<MeetingTypeModel> GetMeetingTypes()
        {
            return _meetingServiceProvider.GetMeetingTypes();
        }

        // GET: api/Meeting/5
        public List<MeetingItemModel> GetMeetingTypeItem(Guid meetingTypeId, Guid meetingId)
        {
            return _meetingServiceProvider.GetMeetingItemsByMeetingTypeId(meetingTypeId, meetingId);
        }

        // POST: api/Meeting
        [HttpPost]
        public bool CreateMeeting(MeetingModel saveMeeting)
        {
            return _meetingServiceProvider.CreateMeeting(saveMeeting);
        }

        public List<MeetingModel> GetMeetings()
        {
            return _meetingServiceProvider.GetMeetings();
        }

        public List<MeetingTypeModel> GetMeetingTypesByMeetingId(Guid meetingId)
        {
            return _meetingServiceProvider.GetMeetingTypesByMeetingId(meetingId);
        }

        public List<StatusModel> GetStatuses()
        {
            return _meetingServiceProvider.GetStatuses();
        }
         
        // PUT: api/Meeting/5
        [HttpPut]
        public bool UpateMeetingItemStatus(MeetingModel updateMeetingItemStatus)
        {
            return _meetingServiceProvider.updateMeetingItemStatus(updateMeetingItemStatus);
        }

        // DELETE: api/Meeting/5
        public void Delete(int id)
        {
        }
    }
}
