CREATE TABLE [dbo].[Category] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (128) NOT NULL,
    [ItemOrder] TINYINT        NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

