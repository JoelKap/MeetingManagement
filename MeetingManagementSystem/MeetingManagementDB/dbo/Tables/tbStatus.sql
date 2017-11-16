CREATE TABLE [dbo].[tbStatus] (
    [StatusId]   UNIQUEIDENTIFIER NOT NULL,
    [StatusName] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_tbStatus] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

