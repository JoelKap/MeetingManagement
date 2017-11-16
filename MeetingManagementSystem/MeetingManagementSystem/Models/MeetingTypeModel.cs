using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingManagementSystem.Models
{
    public class MeetingTypeModel
    {
        public Guid MeetingTypeId { get; set; }
        public string MeetingTypeName { get; set; }
        public string MeetingTypeCode { get; set; }
        public List<MeetingItemModel> MeetingItems { get; set; }

    }
}