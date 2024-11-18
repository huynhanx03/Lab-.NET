using Candidate_BusinessObjects;
using Candidate_Repository;

namespace Candidate_Service
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo iAccountRepo;

        public HRAccountService()
        {
            iAccountRepo = new HRAccountRepo();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccountsList()
        {
            return iAccountRepo.GetHraccountsList();
        }
    }
}
