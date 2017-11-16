using MeetingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagementSystem.Interface
{
   public interface IMeetingServiceProvider
    {
        List<MeetingTypeModel> GetMeetingTypes();
        List<MeetingItemModel> GetMeetingItemsByMeetingTypeId(Guid meetingTyeId, Guid meetingId);
        bool CreateMeeting(MeetingModel saveMeeting);
        List<MeetingModel> GetMeetings();
        List<StatusModel> GetStatuses();
        bool updateMeetingItemStatus(MeetingModel updateMeetingItemStatus);
        List<MeetingTypeModel> GetMeetingTypesByMeetingId(Guid meetingId);

    }
}
