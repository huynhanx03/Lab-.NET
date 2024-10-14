using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool DeleteEmployee(Employee employee)
            => EmployeeDAO.Instance.DeleteEmployee(employee);

        public Employee GetEmployeeById(string empID)
            => EmployeeDAO.Instance.GetEmployeeById(empID);

        public List<Employee> GetEmployeeList()
            => EmployeeDAO.Instance.GetEmployeeList();

        public bool InsertEmployee(Employee employee)
            => EmployeeDAO.Instance.InsertEmployee(employee);

        public List<Employee> SerachEmployeeByDepartmentName(string searchValue)
            => EmployeeDAO.Instance.SerachEmployeeByDepartmentName(searchValue);

        public bool UpdateEmployee(Employee newEmployee)
            => EmployeeDAO.Instance.UpdateEmployee(newEmployee);
    }
}
