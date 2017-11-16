CREATE TABLE [dbo].[tbMeetingType](
	[MeetingTypeId] [uniqueidentifier] NOT NULL,
	[MeetingTypeName] [varchar](50) NOT NULL,
	[MeetingTypeCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbMeetingType] PRIMARY KEY CLUSTERED 
(
	[MeetingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
