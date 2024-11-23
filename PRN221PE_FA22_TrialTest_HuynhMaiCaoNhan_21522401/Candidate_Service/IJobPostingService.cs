using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface IJobPostingService
    {
        public List<JobPosting> getJobPostingsList();
        public JobPosting getJobPostingById(String id);
    }
}
