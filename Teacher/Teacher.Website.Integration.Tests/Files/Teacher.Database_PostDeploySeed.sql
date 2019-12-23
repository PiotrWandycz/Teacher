SET IDENTITY_INSERT [dbo].[Category] ON;

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(101, 'Cat 1', 20);

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(102, 'Cat 2', 21);

INSERT INTO [dbo].[Category]([Id], [Name], [ItemOrder])
VALUES(103, 'Cat 3', 22);

SET IDENTITY_INSERT [dbo].[Category] OFF;



SET IDENTITY_INSERT [dbo].[Question] ON;

INSERT INTO [dbo].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(201, 101, 'Que 1', 'Ans 1');

INSERT INTO [dbo].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(202, 101, 'Que 2', 'Ans 2');

INSERT INTO [dbo].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(203, 102, 'Que 3', 'Ans 3');

INSERT INTO [dbo].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(204, 102, 'Que 4', NULL);

SET IDENTITY_INSERT [dbo].[Question] OFF;