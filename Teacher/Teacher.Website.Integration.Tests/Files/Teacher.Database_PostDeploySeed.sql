SET IDENTITY_INSERT [dbo].[Category] ON;

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(101, 'Programowanie obiektowe', 20);

SET IDENTITY_INSERT [dbo].[Category] OFF;