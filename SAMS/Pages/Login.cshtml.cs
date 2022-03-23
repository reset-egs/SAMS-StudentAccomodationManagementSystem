using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages
{
    public class LoginModel : PageModel
    {
        private IUserService service;

        public LoginModel(IUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        //public User LoggedInUser { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            username = Username;
            password = Password;
            User LoggedInUser = new User();
            LoggedInUser = service.Login(Username, Password);

            if(LoggedInUser.Username != null)
            {
                HttpContext.Session.SetString("logged_in", "true");
                return RedirectToPage("/Welcome");
            }
            else
            {
                return RedirectToPage("/Error");
            }
            
        }
    }
}
