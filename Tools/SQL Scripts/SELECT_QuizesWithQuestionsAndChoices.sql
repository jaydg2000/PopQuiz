SET STATISTICS IO ON
SET STATISTICS TIME ON
SET STATISTICS XML ON
GO

SELECT q.Id as QuizID, q.Name, Q.Description, qu.Id as QuestionId, qu.QuestionText, ch.Id as ChoiceId, ch.ChoiceText, ch.IsCorrect
  FROM [bc_Quiz].[dbo].[Quizes] q
	LEFT JOIN [bc_Quiz].[dbo].[Question] qu ON qu.QuizId = q.Id
	LEFT JOIN [bc_Quiz].[dbo].[Choice] ch ON ch.QuestionId = qu.Id;

GO

SET STATISTICS XML OFF
GO


-- select * from quizes
-- select * from question