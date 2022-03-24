namespace SAMS.Pages
{
    public class MessageModel : PageModel
    {
        private IUserService service;
        public MessageModel(IUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Message Message { get; set; }
        [BindProperty]
        public string? Username { get; set; }
        public async Task OnGetAsync()
        {
            Username = HttpContext.Session.GetString("logged_in");
            Message = await service.GetMessageAsync(Username);
            
        }
    }
}
