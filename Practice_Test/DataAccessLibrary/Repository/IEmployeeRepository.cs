using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployeeList();
        public List<Employee> SerachEmployeeByDepartmentName(string searchValue);
        public Employee GetEmployeeById(string empID);
        public bool DeleteEmployee(Employee employee);
        public bool UpdateEmployee(Employee newEmployee);
        public bool InsertEmployee(Employee employee);
    }
}
