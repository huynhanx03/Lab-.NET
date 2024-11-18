using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepo iCandidateProfileRepo;

        public CandidateProfileService()
        {
            iCandidateProfileRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepo.AddCandidateProfile(candidateProfile);
        }

        public CandidateProfile GetCandidateProfileById(string id)
        {
            return iCandidateProfileRepo.GetCandidateProfileById(id);
        }

        public List<CandidateProfile> GetCandidateProfilesList()
        {
            return iCandidateProfileRepo.GetCandidateProfilesList();
        }

        public bool RemoveCandidateProfile(string id)
        {
            return iCandidateProfileRepo.RemoveCandidateProfile(id);
        }

        public bool UpdateCandidateProfile(CandidateProfile candidate)
        {
            return iCandidateProfileRepo.UpdateCandidateProfile(candidate);
        }

        public List<CandidateProfile> GetCandidateProfilesByName(string name)
        {
            return iCandidateProfileRepo.GetCandidateProfilesByName(name);
        }

        public List<CandidateProfile> GetCandidateProfileByDescription(string description)
        {
            return iCandidateProfileRepo.GetCandidateProfileByDescription(description);
        }
    }
}
