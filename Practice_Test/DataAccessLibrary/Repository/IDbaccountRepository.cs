using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public interface IDbaccountRepository
    {
        public Dbaccount CheckLogin(string username, string password);
    }
}
