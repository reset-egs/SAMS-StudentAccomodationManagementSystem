namespace SAMS.Pages.Apartments
{
    public class GetApartmentsModel : PageModel
    {
        private IApartmentService service;
        public GetApartmentsModel(IApartmentService service)
        {
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<Apartment> Apartments { get; set; }

        public async Task OnGetAsync()
        {
            Apartments = await service.GetApartmentsAsync();
        }
    }
}
