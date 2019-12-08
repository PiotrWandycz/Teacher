SET IDENTITY_INSERT [dbo].[Category] ON;

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(101, 'Cat1', 20);

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(102, 'Cat2', 21);

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(103, 'Cat3', 22);

SET IDENTITY_INSERT [dbo].[Category] OFF;