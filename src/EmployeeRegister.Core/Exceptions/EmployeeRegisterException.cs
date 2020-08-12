using System;

namespace EmployeeRegister.Core.Models
{
    public class EmployeeRegisterException : Exception
    {
        public EmployeeRegisterException(string message) : base(message)
        {

        }
    }
}
