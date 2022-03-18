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

        public void OnGet(int no)
        {
            Student = service.GetStudentByNo(no);
        }

        public IActionResult OnPost(int no)
        {
            Student = service.GetStudentByNo(no);
            service.DeleteStudent(Student.Student_No);
            return RedirectToPage("GetStudents");
        }
    }
}
