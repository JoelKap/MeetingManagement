namespace MeetingManagementSystem
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MeetingContext : DbContext
    {
        public MeetingContext()
            : base("name=MeetingContext")
        {
        }

        public virtual DbSet<tbMeeting> tbMeetings { get; set; }
        public virtual DbSet<tbMeetingItem> tbMeetingItems { get; set; }
        public virtual DbSet<tbMeetingType> tbMeetingTypes { get; set; }
        public virtual DbSet<tbStatu> tbStatus { get; set; }
        public virtual DbSet<tbmeetingTypeItem> tbmeetingTypeItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbMeeting>()
                .Property(e => e.MeetingName)
                .IsUnicode(false);

            modelBuilder.Entity<tbMeetingItem>()
                .Property(e => e.MeetingItemName)
                .IsUnicode(false);

            modelBuilder.Entity<tbMeetingItem>()
                .Property(e => e.PersonAssigned)
                .IsUnicode(false);

            modelBuilder.Entity<tbMeetingType>()
                .Property(e => e.MeetingTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<tbMeetingType>()
                .Property(e => e.MeetingTypeCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbStatu>()
                .Property(e => e.StatusName)
                .IsUnicode(false);
        }
    }
}
