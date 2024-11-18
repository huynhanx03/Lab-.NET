using Candidate_BusinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPostingsList() => JobPostingDAO.Instance.GetJobPostingsList();
        public JobPosting GetJobPostingById(String id) => JobPostingDAO.Instance.getJobPostingById(id);
    }
}
