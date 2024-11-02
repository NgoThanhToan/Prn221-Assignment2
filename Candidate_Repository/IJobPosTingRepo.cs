using Candidate_BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface IJobPosTingRepo
    {
        public JobPosting GetJobPosting(string jobId);

        public List<JobPosting> GetPostings();

        public bool AddJobPosting(JobPosting jobPosting);

        public bool DeleteJobPosting(JobPosting jobPosting);

        public bool UpdateJobPosting(JobPosting jobPosting);

    }
}
