using Candidate_BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext context;
        private static JobPostingDAO instance = null;



        public JobPostingDAO()
        {

            context = new CandidateManagementContext();

        }

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
      
        public JobPosting GetJobPosting(string jobId)
        {
            return context.JobPostings.SingleOrDefault(x => x.PostingId.Equals(jobId));
        }

        public List<JobPosting> GetPostings()
        {
            return context.JobPostings.ToList();
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting jobpost = GetJobPosting(jobPosting.PostingId);

            try
            {
                if (jobpost != null)
                {
                    context.JobPostings.Add(jobPosting);
                    context.SaveChanges();
                    result = true;
                }

            }
            catch (Exception ex)
            {

            }
            return result;

        }
        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting jobpost = GetJobPosting(jobPosting.PostingId);

            try
            {
                if (jobpost != null)
                {
                    context.JobPostings.Add(jobPosting);
                    context.SaveChanges();
                    result = true;
                }

            }
            catch (Exception ex)
            {

            }
            return result;

        }
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting jobpost = GetJobPosting(jobPosting.PostingId);

            try
            {
                if (jobpost != null)
                {
                    context.Entry<JobPosting>(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }

            }
            catch (Exception ex)
            {

            }
            return result;

        }
    }
}

