using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostingsList();
        public JobPosting GetJobPostingById(String id);
    }
}
