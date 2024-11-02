using Candidate_BussinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public CandidateProfile GetCandidateProfileByID(string id) => CadidateProfileDAO.Instance.GetCandidateProfileByID(id);
        public List<CandidateProfile> GetCandidateProfiles() => CadidateProfileDAO.Instance.GetCandidateProfiles();

        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CadidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string profileID) => CadidateProfileDAO.Instance.DeleteCandidateProfile(profileID);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CadidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);


        public bool CheckExist(string id) => CadidateProfileDAO.Instance.CandidateProfileExists(id);
    }

}
