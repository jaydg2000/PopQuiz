using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IQuizRepository Quizes { get; }
        int Commit();
    }
}
