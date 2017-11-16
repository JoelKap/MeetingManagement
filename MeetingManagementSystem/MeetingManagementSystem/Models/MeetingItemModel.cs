using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingManagementSystem.Models
{
    public class MeetingItemModel
    {
        public Guid MeetingItemId { get; set; }
        public string MeetingItemName { get; set; }
        public Guid MeetingItemStatusId { get; set; }
        public string MeetingItemStatusName { get; set; }
        public string PersonAssigned { get; set; }
        public List<StatusModel> MeetingItemStatuses { get; set; }

    }
}