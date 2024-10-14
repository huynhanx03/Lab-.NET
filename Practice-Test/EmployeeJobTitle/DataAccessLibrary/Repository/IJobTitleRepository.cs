using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public interface IJobTitleRepository
    {
        public List<JobTitle> GetJobTitles();
        public JobTitle GetJobTitleByID(string jobtitleID);
    }
}
