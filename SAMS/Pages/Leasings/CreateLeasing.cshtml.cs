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

        [BindProperty(SupportsGet = true)]
        public int Place_No { get;set; }

        public void OnGet(int pNo)
        {
            Place_No = pNo;
        }
        public IActionResult OnPost(int pNo)
        {
            service.CreateLeasing(pNo, Leasing);
            return RedirectToPage("GetLeasings");
        }
    }
}
