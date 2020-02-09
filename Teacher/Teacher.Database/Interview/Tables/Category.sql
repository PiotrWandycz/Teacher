CREATE TABLE [Interview].[Category] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_InterviewCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);



