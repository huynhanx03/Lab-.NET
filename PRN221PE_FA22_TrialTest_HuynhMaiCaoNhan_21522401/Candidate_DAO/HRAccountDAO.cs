using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext dbContext;
        private static HRAccountDAO instance = null;

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public HRAccountDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return dbContext.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }

        public List<Hraccount> GetHraccountsList()
        {
            return dbContext.Hraccounts.ToList();
        }
    }
}
