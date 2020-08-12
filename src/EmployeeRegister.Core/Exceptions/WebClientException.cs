using System;

namespace EmployeeRegister.Core.Models
{
    public class WebClientException : Exception
    {
        public WebClientException(string message) : base(message)
        {

        }
    }
}
