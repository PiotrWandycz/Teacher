CREATE TABLE [Exam].[Path] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_ExamCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

