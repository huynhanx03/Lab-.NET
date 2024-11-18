using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dBContext;
        private static JobPostingDAO instance;

        public static JobPostingDAO Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                    return instance; 
            }
        }

        public JobPostingDAO()
        {
            dBContext = new CandidateManagementContext();
        }

        public List<JobPosting> GetJobPostingsList()
        {
            return dBContext.JobPostings.ToList();

        }

        public JobPosting getJobPostingById(String id)
        {
            return dBContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(id));
        }

    }
}
