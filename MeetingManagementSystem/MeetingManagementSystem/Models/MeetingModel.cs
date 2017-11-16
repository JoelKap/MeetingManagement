using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingManagementSystem.Models
{
    public class MeetingModel
    {
        public Guid MeetingId { get; set; }
        public string MeetingName { get; set; }
        public Guid MeetingTypeId { get; set; }
        public string MeetingTypeName { get; set; }
        public DateTime MeetingDate { get; set; } 
        public DateTime MeetingTime { get; set; }
        public List<MeetingItemModel> MeetingItems { get; set; }

    }
}