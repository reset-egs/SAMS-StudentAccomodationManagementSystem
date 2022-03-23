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
        public async Task OnGet(int no)
        {
            Rooms = await service.GetVacantRoomsAsync(no);
            Apartment = await service.GetApartmentByNoAsync(no);
        }
    }
}
