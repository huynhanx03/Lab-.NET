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

        private string getConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json", true, true)
                                                .Build();
            var strConnection = configuration["ConnectionStrings:EmployeeJobTitle"];
            return strConnection;
        }

        public List<Employee> GetEmployeeList()
        {
            string strConnection = getConnectionString();
            try
            {
                using(EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
                {
                    return dbContext.Employees.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Employee> SerachEmployeeByDepartmentName(string searchValue)
        {
            string strConnection = getConnectionString();
            try
            {
                using (EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
                {
                    return dbContext.Employees.Where(employee => employee.DepartmentName.Contains(searchValue)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee GetEmployeeById(string empID)
        {
            string strConnection = getConnectionString();
            try
            {
                using (EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
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
            string strConnection = getConnectionString();
            try
            {
                using (EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
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
            string strConnection = getConnectionString();
            try
            {
                using (EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
                {
                    dbContext.Entry<Employee>(newEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            string strConnection = getConnectionString();
            try
            {
                using (EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
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
