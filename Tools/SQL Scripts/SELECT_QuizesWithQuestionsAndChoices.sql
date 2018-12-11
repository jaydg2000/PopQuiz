/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Description]
  FROM [bc_Quiz].[dbo].[Quizes]

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT q.Id as QuizID, q.Name, Q.Description, qu.Id as QuestionId, qu.QuestionText, ch.Id as ChoiceId, ch.ChoiceText, ch.IsCorrect
  FROM [bc_Quiz].[dbo].[Quizes] q
	LEFT JOIN [bc_Quiz].[dbo].[Question] qu ON qu.QuizId = q.Id
	LEFT JOIN [bc_Quiz].[dbo].[Choice] ch ON ch.QuestionId = qu.Id;


-- select * from quizes
-- select * from question