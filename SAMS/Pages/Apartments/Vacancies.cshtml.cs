namespace SAMS.Pages.Apartments
{
    public class VacanciesModel : PageModel
    {
        private IApartmentService service;
        public VacanciesModel(IApartmentService service)
        {
            this.service = service;
        }

        public IEnumerable<Room> Rooms { get; set; }

        public Apartment Apartment { get; set; }
        public void OnGet(int no)
        {
            Rooms = service.GetVacantRooms(no);
            Apartment = service.GetApartmentByNo(no);
        }
    }
}
