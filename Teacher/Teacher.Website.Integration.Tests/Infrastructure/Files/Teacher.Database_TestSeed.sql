SET IDENTITY_INSERT [Interview].[Category] ON;

INSERT INTO [Interview].[Category]([Id], [Name])
VALUES(101, 'Cat 1');

INSERT INTO [Interview].[Category]([Id], [Name])
VALUES(102, 'Cat 2');

INSERT INTO [Interview].[Category]([Id], [Name])
VALUES(103, 'Cat 3');

INSERT INTO [Interview].[Category]([Id], [Name])
VALUES(9101, 'Cat 4');

SET IDENTITY_INSERT [Interview].[Category] OFF;



SET IDENTITY_INSERT [Interview].[Question] ON;

INSERT INTO [Interview].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(201, 101, 'Que 1', 'Ans 1');

INSERT INTO [Interview].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(202, 101, 'Que 2', 'Ans 2');

INSERT INTO [Interview].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(203, 102, 'Que 3', 'Ans 3');

INSERT INTO [Interview].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(204, 102, 'Que 4', NULL);

SET IDENTITY_INSERT [Interview].[Question] OFF;