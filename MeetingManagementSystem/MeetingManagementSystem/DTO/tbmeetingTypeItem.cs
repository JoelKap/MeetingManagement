namespace MeetingManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbmeetingTypeItem")]
    public partial class tbmeetingTypeItem
    {
        [Key]
        [Column(Order = 0)]
        public Guid MeetingTypeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid MeetingItemId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid MeetingId { get; set; }
    }
}
