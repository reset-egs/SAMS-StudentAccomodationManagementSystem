namespace SAMS.Pages.Dormitories
{
    public class VacanciesModel : PageModel
    {
        private IDormitoryService service;

        public VacanciesModel(IDormitoryService service)
        {
            this.service = service;
        }

        public IEnumerable<Room> Rooms { get; set; }

        public Dormitory Dormitory { get; set; }

        public void OnGet(int no)
        {
            Rooms = service.GetVacantRooms(no);
            Dormitory = service.GetDormitoryByNo(no);
        }
    }
}
