using System;
using System.ComponentModel.DataAnnotations;
using EmployeeRegister.Attributes;

namespace EmployeeRegister.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Department { get; set; }
        
        [Required]
        [DateBirthRangeAttribute]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        
        public int? ManagerId { get; set; }
    }
}
