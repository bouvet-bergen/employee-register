using System;

namespace EmployeeRegister.Core.Models
{
    public class EmployeeRegisterBadRequestException : Exception
    {
        public EmployeeRegisterBadRequestException(string message) : base(message)
        {

        }
    }
}
