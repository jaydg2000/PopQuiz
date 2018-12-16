using System.Collections.Generic;

namespace PopQuiz.Service.Quiz.Application.Models
{
    public class GetListOfQuestionsQueryResponse
    {
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}