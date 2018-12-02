using PopQuiz.Service.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Common.Exceptions
{
    public class EntityNotFoundException : ServiceOperationException
    {
        public EntityNotFoundException(string message)
            : base(message) { }
    }
}
