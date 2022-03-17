namespace SAMS.Pages.Dormitories
{
    public class GetDormitoriesModel : PageModel
    {
        private IDormitoryService service;
        public GetDormitoriesModel(IDormitoryService service)
        {
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<Dormitory> Dormitories { get; set; }

        public void OnGet()
        {
            Dormitories = service.GetDormitories();
        }
    }
}
