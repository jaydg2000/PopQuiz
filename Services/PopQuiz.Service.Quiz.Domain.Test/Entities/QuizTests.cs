using PopQuiz.Service.Quiz.Domain.Entities;
using Xunit;

namespace PopQuiz.Service.Quiz.Domain.Test.Entities
{
    public class QuizTests
    {
        [Fact]
        public void CanCreateQuizEntity()
        {
            int id = 1;
            string name = "Name";
            string description = "Description";

            ProctoredQuiz target = new ProctoredQuiz(id, name, description);

            Assert.Equal(id, target.Id);
            Assert.Equal(name, target.Name);
            Assert.Equal(description, target.Description);
        }
    }
}
