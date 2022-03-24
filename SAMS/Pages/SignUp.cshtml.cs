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
            //if (ModelState.IsValid == true)
            //{
                user = User;
/*                try {*/ await service.SignUpAsync(user.Username, user.Password, user.Student_No);
                    return RedirectToPage("/Index");
        //        }
        //        catch (Exception e)
        //        {
        //            return Page();
        //        }
                
        //    }
        //    else
        //    {
        //        return Page();
        //    }
      }
    }
}
