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
                lock(InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DbaccountDAO();
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

        public Dbaccount CheckLogin(string username, string password)
        {
            try
            {
                string strConnection = getConnectionString();
                using(EmployeeJobTitleContext dbContext = new EmployeeJobTitleContext(strConnection))
                {
                   return dbContext.Dbaccounts.SingleOrDefault(account => account.AccountId.Equals(username) 
                    && account.AccountPassword.Equals(password));
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
