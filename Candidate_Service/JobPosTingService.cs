using Azure.Core;
using Candidate_BussinessObjects;
using Candidate_DAO;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobPosTingService : IJobPosTingService
    {
        private  readonly IJobPosTingRepo repo;

        public JobPosTingService()
        {
            repo = new JobPosTingRepo();    
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return repo.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
           return repo.DeleteJobPosting(jobPosting) ;
        }

        public JobPosting GetJobPosting(string jobId)
        {
            return repo.GetJobPosting(jobId) ;
        }

        public List<JobPosting> GetJobPostings()
        {
            return repo.GetPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return UpdateJobPosting(jobPosting);
        }
    }
}
