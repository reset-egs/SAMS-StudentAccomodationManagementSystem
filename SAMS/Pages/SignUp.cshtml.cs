using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages
{
    public class SignUpModel : PageModel
    {
        private IUserService service;
        
        public SignUpModel(IUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(User user)
        {
            user = User;
            await service.SignUpAsync(user.Username, user.Password, user.Student_No);
            return RedirectToPage("/Index");
        }
    }
}
