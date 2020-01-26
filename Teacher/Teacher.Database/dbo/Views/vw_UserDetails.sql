CREATE VIEW
	[dbo].[vw_UserDetails]
	AS

SELECT 
ANU.Id as AspNetUserId
, U.Id as UserId
, ANU.UserName as UserName
FROM AspNetUsers ANU
INNER JOIN [User] U
ON ANU.Id = U.AspNetUserId