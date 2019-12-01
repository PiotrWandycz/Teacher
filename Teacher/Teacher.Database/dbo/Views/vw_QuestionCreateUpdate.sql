CREATE VIEW
	[dbo].[vw_QuestionCreateUpdate]
	AS

SELECT 
Q.Id as QuestionId
, C.Id as CategoryId
, C.[Name] as CategoryName
, Q.Content as Content
, Q.[Level] as [Level]
, Q.AnswerJunior as AnswerJunior
, Q.AnswerRegular as AnswerRegular
, Q.AnswerSenior as AnswerSenior
FROM Question Q
INNER JOIN Category C
ON Q.CategoryId = C.Id