CREATE TABLE [dbo].[Question] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]    INT            NULL,
    [Content]       NVARCHAR (MAX) NOT NULL,
    [Answer]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

