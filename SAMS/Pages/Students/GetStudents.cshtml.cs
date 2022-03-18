using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages.Students
{
    public class GetStudentsModel : PageModel
    {
        private IStudentService service;
        public GetStudentsModel(IStudentService service)
        {
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<Student> Students { get; set; }
        public bool WaitingListOpen { get; set; }

        public void OnGet()
        {
            Students = service.GetStudents();
            WaitingListOpen = false;
        }
        public void OnPost()
        {
            Students = service.GetWaitingList();
            WaitingListOpen = true;

        }
    }
}