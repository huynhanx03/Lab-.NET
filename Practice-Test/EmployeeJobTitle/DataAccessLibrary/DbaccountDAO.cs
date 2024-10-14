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
    public class DbaccountDAO
    {
        private DbaccountDAO() { }
        private static DbaccountDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static DbaccountDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DbaccountDAO();
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

        public Dbaccount CheckLogin(string username, string password)
        {
            try
            {
                string connectionString = GetConnectionString();

                var optionsBuilder = new DbContextOptionsBuilder<EmployeeJobTitleContext>();
                optionsBuilder.UseSqlServer(connectionString);

                using (EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(optionsBuilder.Options))
                {
                    return dbContext.Dbaccounts.SingleOrDefault(account =>
                        account.AccountId.Equals(username) &&
                        account.AccountPassword.Equals(password));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
