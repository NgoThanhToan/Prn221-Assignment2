using System;
using Candidate_Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BussinessObjects;

namespace Candidate_Service
{
    public class CandidatePRofileService : ICandidateProfileService
    {
        private ICandidateProfileRepo Profilerepo;

        public CandidatePRofileService()
        {
            Profilerepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return Profilerepo.AddCandidateProfile(candidateProfile); 
        }

        public bool DeleteCandidateProfile(string profileID)
        {
           return Profilerepo.DeleteCandidateProfile(profileID);
        }

        public CandidateProfile GetCandidateProfileByID(string id)
        {
            return Profilerepo.GetCandidateProfileByID(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return Profilerepo.GetCandidateProfiles();
        }

        public bool CheckExists(string id)
        {
            return Profilerepo.CheckExist(id);
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return Profilerepo.UpdateCandidateProfile(candidateProfile);
        }
    }
}
