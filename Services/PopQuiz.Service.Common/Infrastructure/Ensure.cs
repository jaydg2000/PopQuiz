using System;
using System.Collections.Generic;
using System.Text;
using PopQuiz.Service.Common.Domain.Infrastructure;
using PopQuiz.Service.Common.Exceptions;

namespace PopQuiz.Service.Common.Infrastructure
{
    public static class Ensure
    {
        public static void Entity(DomainEntity entity, string name, int id)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException(name, id);
            }
        }
    }
}
