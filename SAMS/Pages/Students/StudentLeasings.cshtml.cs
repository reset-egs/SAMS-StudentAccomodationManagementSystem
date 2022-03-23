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

        public async Task OnGetAsync(int no)
        {
            StudentLeasingsViewModel = await service.GetStudentLeasingsAsync(no);
        }
    }
}
