CREATE VIEW
	[dbo].[vw_QuestionDetails]
	AS

SELECT 
Q.Id as QuestionId
, C.Id as CategoryId
, C.[Name] as CategoryName
, Q.Content as Content
, Q.Answer as Answer
FROM Question Q
INNER JOIN Category C
ON Q.CategoryId = C.Id