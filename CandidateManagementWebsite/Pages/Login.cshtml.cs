using Candidate_BussinessObjects;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsite.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHRAccountService _service;

        public LoginModel(IHRAccountService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public async void OnPost()
        {
            string email = Request.Form["txtUsername"];
            string password = Request.Form["txtPwd"];

            Hraccount account =   _service.GetHraccountByEmail(email);
            if (account != null && account.Password.Equals(password))
            {
                string RoleID = account.MemberRole.ToString();
                HttpContext.Session.SetString("RoleID", RoleID);
                Response.Redirect("/CandidateProfilePage");
            }
            else
            {
                Response.Redirect("/Error");
            }
        }
    }
}
