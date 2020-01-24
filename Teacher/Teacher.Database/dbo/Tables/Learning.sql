CREATE TABLE [dbo].[Learning] (
    [Id]     INT           NOT NULL,
    [UserId] INT           NOT NULL,
    [Date]   DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Learning] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Learning_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

