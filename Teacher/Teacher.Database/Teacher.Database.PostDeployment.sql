/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
    VALUES('system', 'admin', 'ADMIN', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEAihBvP+LNNYMsiRW1OLnpsAW2g2iQtMybykor+mGL+GycOwQrzv5Zs8McYC4ddjPw==', 'D5A3TYLRQKI33IRITK3VTW7OTS4PT7I7', '64fb7a7f-3a9a-4ee7-b0f8-8fea9521584b', NULL, 0, 0, NULL, 1, 0)



DECLARE @Cat1Id int;

INSERT INTO [Interview].[Category]([Name])
	VALUES ('Programowanie obiektowe');

SET @Cat1Id = SCOPE_IDENTITY();	

INSERT INTO [Interview].[Question](CategoryId, Content, Answer)
VALUES (@Cat1Id, 'Question 1', NULL),
(@Cat1Id, 'Question 2', 'Answer'),
(@Cat1Id, 'Question 3', 'Answer'),
(@Cat1Id, 'Question 4', 'Answer');



DECLARE @Cat2Id int;

INSERT INTO [Interview].[Category]([Name])
	VALUES ('SQL Server');

SET @Cat2Id = SCOPE_IDENTITY();	

INSERT INTO [Interview].[Question](CategoryId, Content, Answer)
VALUES (@Cat2Id, 'Question 1', 'Answer'),
(@Cat2Id, 'Question 2', NULL),
(@Cat2Id, 'Question 3', 'Answer'),
(@Cat2Id, 'Question 4', 'Answer');

	

DECLARE @Cat3Id int;

INSERT INTO [Interview].[Category]([Name])
	VALUES ('Wzorce projektowe');

SET @Cat3Id = SCOPE_IDENTITY();	

INSERT INTO [Interview].[Question](CategoryId, Content, Answer)
VALUES (@Cat3Id, 'Question 1', 'Answer'),
(@Cat3Id, 'Question 2', 'Answer'),
(@Cat3Id, 'Question 3', NULL);