namespace MeetingManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbMeeting")]
    public partial class tbMeeting
    {
        [Key]
        public Guid MeetingId { get; set; }

        public Guid MeetingTypeId { get; set; }

        public DateTime MeetingDate { get; set; }

        public DateTime MeetingTime { get; set; }

        [Required]
        [StringLength(50)]
        public string MeetingName { get; set; }
    }
}
