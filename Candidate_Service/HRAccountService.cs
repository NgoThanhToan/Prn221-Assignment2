using Candidate_BussinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class HRAccountService : IHRAccountService
    {

        private IHRAccountRepo _repo;

        public HRAccountService() { 

            _repo = new  HRAcccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return _repo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return _repo.GetHraccounts();
        }
    }
}
