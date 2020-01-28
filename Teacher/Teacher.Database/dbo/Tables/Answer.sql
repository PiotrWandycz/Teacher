CREATE TABLE [dbo].[Answer] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [QuestionId]       INT           NOT NULL,
    [UserId]           INT           NOT NULL,
    [AnsweredAt]       DATETIME2 (7) NOT NULL,
    [WasAnswerCorrect] BIT       NOT NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]),
    CONSTRAINT [FK_Answer_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

