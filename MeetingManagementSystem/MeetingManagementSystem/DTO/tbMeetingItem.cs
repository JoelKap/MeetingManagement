namespace MeetingManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbMeetingItem")]
    public partial class tbMeetingItem
    {
        [Key]
        public Guid MeetingItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string MeetingItemName { get; set; }

        public Guid MeetingItemStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonAssigned { get; set; }
    }
}
