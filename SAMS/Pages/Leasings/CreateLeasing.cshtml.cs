using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages.Leasings
{
    public class CreateLeasingModel : PageModel
    {
        private ILeasingService service;
        public CreateLeasingModel(ILeasingService service)
        {
            this.service = service;
        }
        [BindProperty]
        public Leasing Leasing { get; set; }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost(int pNo)
        {
            service.CreateLeasing(pNo, Leasing);
            return RedirectToPage("GetLeasings");
        }
    }
}
