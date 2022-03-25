using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages.Students
{
    public class GetStudentsModel : PageModel
    {
        private IStudentService service;
        private ILeasingService leasingService;
        public GetStudentsModel(IStudentService service, ILeasingService leasingService)
        {
            this.leasingService = leasingService;
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<Student> Students { get; set; }
        public bool WaitingListOpen { get; set; }
        public IEnumerable<Leasing> Leasings { get; set; }

        public async Task OnGetAsync()
        {
            Students = await service.GetStudentsAsync();
            Leasings = await leasingService.GetLeasingsAsync();
            WaitingListOpen = false;
        }
        public void OnPost()
        {
            Students = service.GetWaitingList();
            WaitingListOpen = true;

        }
    }
}
