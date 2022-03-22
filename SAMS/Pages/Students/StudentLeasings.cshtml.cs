using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages.Students
{
    public class StudentLeasingsModel : PageModel
    {
        private IStudentService service;

        public StudentLeasingsModel(IStudentService service)
        {
            this.service = service;
        }

        public StudentLeasingsViewModel StudentLeasingsViewModel { get; set; }

        public void OnGet(int no)
        {
            StudentLeasingsViewModel = service.GetStudentLeasings(no);
        }
    }
}
