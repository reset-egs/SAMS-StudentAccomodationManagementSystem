namespace SAMS.Pages.Leasings
{
    public class GetLeasingsModel : PageModel
    {
        private ILeasingService service;
        public GetLeasingsModel(ILeasingService service)
        {
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<Leasing> Leasings { get; set; }

        public async Task OnGetAsync()
        {
            Leasings = await service.GetLeasingsAsync();
        }
    }
}
