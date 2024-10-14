using System;
using System.Collections.Generic;

#nullable disable

namespace MyLibrabry.Models
{
    public partial class Employee
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? YearOfBirth { get; set; }
        public string DepartmentName { get; set; }
        public string JobTitleId { get; set; }

        public virtual JobTitle JobTitle { get; set; }
    }
}
