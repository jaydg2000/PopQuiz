using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Common.Exceptions
{
    public abstract class ServiceOperationException : Exception
    {
        public ServiceOperationException(string message)
            :base(message)
        {
            // TODO: log message here.
        }
    }
}
