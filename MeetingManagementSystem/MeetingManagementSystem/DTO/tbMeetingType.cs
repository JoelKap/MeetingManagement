namespace MeetingManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbMeetingType")]
    public partial class tbMeetingType
    {
        [Key]
        public Guid MeetingTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string MeetingTypeName { get; set; }

        [Required]
        [StringLength(50)]
        public string MeetingTypeCode { get; set; }
    }
}
