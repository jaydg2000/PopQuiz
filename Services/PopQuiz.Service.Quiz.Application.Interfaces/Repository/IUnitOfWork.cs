using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PopQuiz.Service.Quiz.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
