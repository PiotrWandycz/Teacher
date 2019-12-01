CREATE TABLE [dbo].[Question] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]    INT            NOT NULL,
    [Content]       NVARCHAR (MAX) NOT NULL,
    [Level]         TINYINT        NOT NULL,
    [AnswerJunior]  NVARCHAR (MAX) NULL,
    [AnswerRegular] NVARCHAR (MAX) NULL,
    [AnswerSenior]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

