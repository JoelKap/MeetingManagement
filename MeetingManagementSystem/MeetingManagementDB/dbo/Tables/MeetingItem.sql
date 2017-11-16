CREATE TABLE [dbo].[tbMeetingItem] (
    [MeetingItemId]       UNIQUEIDENTIFIER NOT NULL,
    [MeetingItemName]     VARCHAR (50)     NOT NULL,
    [MeetingItemStatusId] UNIQUEIDENTIFIER NOT NULL,
    [PersonAssigned]      VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_tbMeetingItem] PRIMARY KEY CLUSTERED ([MeetingItemId] ASC)
);



GO
