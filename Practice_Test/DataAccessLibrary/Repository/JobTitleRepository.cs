using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class JobTitleRepository : IJobTitleRepository
    {
        public JobTitle GetJobTitleByID(string jobtitleID)
            => JobTitileDAO.Instance.GetJobTitleByID(jobtitleID);

        public List<JobTitle> GetJobTitles()
            => JobTitileDAO.Instance.GetJobTitles();
    }
}
