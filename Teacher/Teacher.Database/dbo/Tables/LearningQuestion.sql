CREATE TABLE [dbo].[LearningQuestion] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [LearningId]       INT NOT NULL,
    [QuestionId]       INT NOT NULL,
    [WasAnswerCorrect] BIT NOT NULL,
    CONSTRAINT [PK_LearningQuestion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LearningQuestion_Learning] FOREIGN KEY ([LearningId]) REFERENCES [dbo].[Learning] ([Id]),
    CONSTRAINT [FK_LearningQuestion_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

