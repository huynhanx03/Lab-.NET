using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public CandidateProfile GetCandidateProfileById(String id)
        {
            return dbContext.CandidateProfiles.Include(c => c.Posting).SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public List<CandidateProfile> GetCandidatesProfilesList()
        {
            return dbContext.CandidateProfiles.Include(c => c.Posting).ToList();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = this.GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    dbContext.CandidateProfiles.Add(candidateProfile);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool RemoveCandidateProfile(String profileId)
        {
            bool result = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileById(profileId);
            try
            {
                if (candidateProfile != null)
                {
                    dbContext.CandidateProfiles.Remove(candidateProfile);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateCandidateProfile(CandidateProfile updatedCandidate)
        {
            bool result = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileById(updatedCandidate.CandidateId);
            try
            {
                if (candidateProfile != null)
                {
                    candidateProfile.Fullname = updatedCandidate.Fullname;
                    candidateProfile.Birthday = updatedCandidate.Birthday;
                    candidateProfile.ProfileShortDescription = updatedCandidate.ProfileShortDescription;
                    candidateProfile.ProfileUrl = updatedCandidate.ProfileUrl;
                    candidateProfile.PostingId = updatedCandidate.PostingId;

                    dbContext.Entry<CandidateProfile>(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.Update(candidateProfile);
                    dbContext.SaveChanges();
                    result = true;  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<CandidateProfile> GetCandidateProfileByName(string name)
        {
            return dbContext.CandidateProfiles.Where(m => m.Fullname.Contains(name)).ToList();
        }
        
        public List<CandidateProfile> GetCandidateProfileByDescription(string description)
        {
            return dbContext.CandidateProfiles.Where(m => m.ProfileShortDescription.Contains(description)).ToList();
        }

    }
}
