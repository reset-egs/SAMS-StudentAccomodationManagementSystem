using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SAMS.Pages.Rooms
{
    public class GetRoomsModel : PageModel
    {
        private IRoomService service;
        public GetRoomsModel(IRoomService service)
        {
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<Room> Rooms { get; set; }

        public void OnGet()
        {
            Rooms = service.GetRooms();
        }
    }
}
