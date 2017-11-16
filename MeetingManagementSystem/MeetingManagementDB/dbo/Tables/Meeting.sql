CREATE TABLE [dbo].[tbMeeting] (
    [MeetingId]     UNIQUEIDENTIFIER NOT NULL,
    [MeetingTypeId] UNIQUEIDENTIFIER NOT NULL,
    [MeetingDate]   DATETIME         NOT NULL,
    [MeetingTime]   DATETIME         NOT NULL,
    [MeetingName]   VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_tbMeeting] PRIMARY KEY CLUSTERED ([MeetingId] ASC)
);



GO
