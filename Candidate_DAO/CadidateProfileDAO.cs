using System;
using Candidate_BussinessObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAO
{
    public class CadidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CadidateProfileDAO instance = null;


        public CadidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }

        public static CadidateProfileDAO Instance
        {

            get
            {
                if (instance == null)
                {

                    instance = new CadidateProfileDAO();

                }

                return instance;
            }
        }

        public CandidateProfile GetCandidateProfileByID(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(x => x.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.ToList();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = this.GetCandidateProfileByID(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;


            }
            return isSuccess;

        }
        public bool DeleteCandidateProfile(string profileID)
        {
            bool isSuccess = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileByID(profileID);
            try
            {
                if (candidateProfile != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);
                }


            }
            return isSuccess;


        }
        public bool UpdateCandidateProfile(CandidateProfile cadidate)
        {
            bool isSuccess = false;

            try
            {
                var candidateProfile = context.CandidateProfiles.FirstOrDefault(p => p.CandidateId == cadidate.CandidateId);
                if (candidateProfile != null)
                {
                    candidateProfile.Fullname = cadidate.Fullname;
                    candidateProfile.Birthday = cadidate.Birthday;
                    candidateProfile.ProfileShortDescription = cadidate.ProfileShortDescription;
                    candidateProfile.ProfileUrl = cadidate.ProfileUrl;

                    context.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    throw new KeyNotFoundException($"CandidateProfile with ID {cadidate.CandidateId}not found.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }

            return isSuccess;


        }
        private void LogError(Exception ex)
        {         // Ghi log lỗi vào console (hoặc bạn có thể ghi vào file hoặc cơ sở dữ liệu)
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }


        public bool CandidateProfileExists(string id)
        {
            return context.CandidateProfiles.Any(e => e.CandidateId == id);
        }

    }
}



//public bool UpdateCandidateProfile(CandidateProfile candidate)
//{
//    bool isSuccess = false;

//    try
//    {
//        // Kiểm tra xem thực thể đã được theo dõi chưa
//        var existingProfile = context.CandidateProfiles
//                                     .FirstOrDefault(p => p.CandidateId == candidate.CandidateId);

//        if (existingProfile != null)
//        {
//            // Cập nhật các thuộc tính từ candidate vào existingProfile
//            existingProfile.Fullname = candidate.Fullname;
//            existingProfile.Birthday = candidate.Birthday;
//            existingProfile.ProfileShortDescription = candidate.ProfileShortDescription;
//            existingProfile.ProfileUrl = candidate.ProfileUrl;

//            context.SaveChanges();
//            isSuccess = true;
//        }
//        else
//        {
//            throw new KeyNotFoundException($"CandidateProfile with ID {candidate.CandidateId} not found.");
//        }
//    }
//    catch (DbUpdateException dbEx)
//    {
//        LogError(dbEx); // Ghi log lỗi cụ thể cho việc cập nhật cơ sở dữ liệu
//        throw; // Ném lại ngoại lệ gốc
//    }
//    catch (Exception ex)
//    {
//        LogError(ex); // Ghi log lỗi khác
//        throw; // Ném lại ngoại lệ gốc
//    }

//    return isSuccess;
//}



//public bool UpdateCandidateProfile(CandidateProfile cadidate)
//{
//    bool isSuccess = false;

//    try
//    {
//        var candidateProfile = context.CandidateProfiles.FirstOrDefault(p => p.CandidateId == cadidate.CandidateId);
//        if (candidateProfile != null)
//        {
//            candidateProfile.Fullname = cadidate.Fullname;
//            candidateProfile.Birthday = cadidate.Birthday;
//            candidateProfile.ProfileShortDescription = cadidate.ProfileShortDescription;
//            candidateProfile.ProfileUrl = cadidate.ProfileUrl;
//            context.SaveChanges();
//            isSuccess = true;
//        }
//        else
//        {
//            throw new KeyNotFoundException($"CandidateProfile with ID {cadidate.CandidateId}not found.");
//        }
//    }
//    catch (DbUpdateException x)
//    {
//        LogError(x);
//        throw;
//    }
//    catch (Exception ex)
//    {
//        LogError(ex);
//        throw;
//    }

//    return isSuccess;


//}