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

INSERT INTO [Interview].[Question]([Id], [CategoryId], [Content], [Answer])
VALUES(90210, 102, 'Que 5', NULL);

SET IDENTITY_INSERT [Interview].[Question] OFF;



INSERT INTO [dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
    VALUES('test', 'test', 'TEST', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEAihBvP+LNNYMsiRW1OLnpsAW2g2iQtMybykor+mGL+GycOwQrzv5Zs8McYC4ddjPw==', 'D5A3TYLRQKI33IRITK3VTW7OTS4PT7I7', '64fb7a7f-3a9a-4ee7-b0f8-8fea9521584b', NULL, 0, 0, NULL, 1, 0)

SET IDENTITY_INSERT [dbo].[User] ON;

DELETE FROM [dbo].[User] WHERE [AspNetUserId] = 'test';
INSERT INTO [dbo].[User]([Id], [AspNetUserId])
	VALUES (50, 'test');

SET IDENTITY_INSERT [dbo].[User] OFF;
