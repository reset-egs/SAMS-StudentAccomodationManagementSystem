namespace SAMS.Pages.Students
{
    public class DeleteStudentModel : PageModel
    {
        private IStudentService service;
        public DeleteStudentModel(IStudentService service)
        {
            this.service = service;
        }

        public Student Student { get; set; }

        public async Task OnGetAsync(int no)
        {
            Student = await service.GetStudentByNoAsync(no);
        }

        public async Task<IActionResult> OnPostAsync(int no)
        {
            Student = await service.GetStudentByNoAsync(no);
            await service.DeleteStudentAsync(Student.Student_No);
            return RedirectToPage("GetStudents");
        }
    }
}
