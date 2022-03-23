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

        public async Task OnGetAsync(int no)
        {
            Rooms = await service.GetVacantRoomsAsync(no);
            Dormitory = await service.GetDormitoryByNoAsync(no);
        }
    }
}
