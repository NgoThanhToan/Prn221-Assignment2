using Candidate_BussinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobPosTingRepo : IJobPosTingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);
       

        public bool DeleteJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.DeleteJobPosting(jobPosting);


        public JobPosting GetJobPosting(string jobId) => JobPostingDAO.Instance.GetJobPosting(jobId);

        

        public List<JobPosting> GetPostings() => JobPostingDAO.Instance.GetPostings();


        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
       
    }
}
