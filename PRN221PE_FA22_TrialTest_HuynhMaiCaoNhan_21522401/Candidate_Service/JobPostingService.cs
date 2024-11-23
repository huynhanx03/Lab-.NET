using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobPostingService: IJobPostingService
    {
        private JobPostingRepo iJobPostingRepo;
        public JobPostingService() 
        {
            iJobPostingRepo = new JobPostingRepo();
        }

        public JobPosting getJobPostingById(String id)
        {
            return iJobPostingRepo.GetJobPostingById(id);
        }

        public List<JobPosting> getJobPostingsList()
        {
            return iJobPostingRepo.GetJobPostingsList();
        }

    }
}
