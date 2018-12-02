/****** Script for SelectTopNRows command from SSMS  ******/
SELECT q.Id as QuizID, q.Name, Q.Description, qu.Id as QuestionId, qu.QuestionText, ch.Id as ChoiceId, ch.ChoiceText, ch.IsCorrect
  FROM Quizes q
	LEFT JOIN Question qu ON qu.QuizId = q.Id
	LEFT JOIN Choice ch ON ch.QuestionId = qu.Id;


-- select * from quizes
-- select * from question