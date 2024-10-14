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
    public class JobTitileDAO
    {
        private JobTitileDAO() { }
        private static JobTitileDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static JobTitileDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new JobTitileDAO();
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

        public List<JobTitle> GetJobTitles()
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    return dbContext.JobTitles.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JobTitle GetJobTitleByID(string jobtitleID)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    return dbContext.JobTitles.SingleOrDefault(job => job.JobTitleId.Equals(jobtitleID));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
