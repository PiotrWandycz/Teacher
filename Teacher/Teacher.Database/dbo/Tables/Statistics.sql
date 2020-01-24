CREATE TABLE [dbo].[Statistics] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [UserId]            INT           NOT NULL,
    [LearningId]        INT           NOT NULL,
    [Date]              DATETIME2 (7) NOT NULL,
    [QuestionsAnswered] INT           NOT NULL,
    [CorrectAnswers]    INT           NOT NULL,
    [IncorrectAnswers]  INT           NOT NULL,
    CONSTRAINT [PK_Statistics] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Statistics_Learning] FOREIGN KEY ([LearningId]) REFERENCES [dbo].[Learning] ([Id]),
    CONSTRAINT [FK_Statistics_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

