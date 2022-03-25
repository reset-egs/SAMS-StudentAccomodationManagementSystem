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

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            username = Username;
            password = Password;
            User LoggedInUser = new User();
            try
            {
                LoggedInUser = await service.LoginAsync(Username, Password);
            }
            catch (Exception ex)
            {
                return Page();
            }


            if (LoggedInUser.Username != null)
            {
                HttpContext.Session.SetString("logged_in", $"{LoggedInUser.Student_No}");
                return RedirectToPage("/Welcome");
            }
            else
            {
                return RedirectToPage("/Error");
            }

        }
    }
}
