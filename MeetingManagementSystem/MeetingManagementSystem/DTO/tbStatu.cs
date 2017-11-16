namespace MeetingManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbStatu
    {
        [Key]
        public Guid StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }
    }
}
