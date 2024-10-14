using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class EmployeeDAO
    {
        private EmployeeDAO() { }
        private static EmployeeDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static EmployeeDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json", true, true)
                                                .Build();
            return configuration["ConnectionStrings:EmployeeJobTitle"];
        }

        private EmployeeJobTitleContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeJobTitleContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            return new EmployeeJobTitleContext(optionsBuilder.Options);
        }

        public List<Employee> GetEmployeeList()
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    return dbContext.Employees.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Employee> SearchEmployeeByDepartmentName(string searchValue)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    return dbContext.Employees
                        .Where(employee => employee.DepartmentName.Contains(searchValue))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee GetEmployeeById(string empID)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    return dbContext.Employees.SingleOrDefault(emp => emp.EmployeeId.Equals(empID));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteEmployee(Employee employee)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    dbContext.Employees.Remove(employee);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateEmployee(Employee newEmployee)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    dbContext.Entry(newEmployee).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool InsertEmployee(Employee employee)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    dbContext.Employees.Add(employee);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
