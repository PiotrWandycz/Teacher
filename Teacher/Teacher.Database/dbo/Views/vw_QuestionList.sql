CREATE VIEW
	[dbo].[vw_QuestionList]
	AS

SELECT 
Q.Id as QuestionId
, C.Id as CategoryId
, C.[Name] as CategoryName
, Q.Content as Content
, Q.[Level] as [Level]
FROM Question Q
INNER JOIN Category C
ON Q.CategoryId = C.Id