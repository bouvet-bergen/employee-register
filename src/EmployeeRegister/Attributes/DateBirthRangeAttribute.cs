using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EmployeeRegister.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class DateBirthRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var currentValue = (DateTime?) value;
            
            if (currentValue == null)
                return true;

            return currentValue >= new DateTime(1900, 1, 1) && currentValue <= DateTime.Now;
        }

        public override string FormatErrorMessage(string name) => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
    }
}
