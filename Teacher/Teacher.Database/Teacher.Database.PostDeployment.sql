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

INSERT INTO [Interview].[Category]([Name])
	VALUES ('Programowanie obiektowe'), ('SQL Server'), ('Wzorce projektowe')