using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagementWebsite.Data;
using Candidate_BussinessObjects;
using Candidate_Service;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPosTingService jobPostingService;

        public CreateModel(ICandidateProfileService candidateProfileService, IJobPosTingService jobPostingService)
        {
            this.candidateProfileService = candidateProfileService;
            this.jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            candidateProfileService.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
