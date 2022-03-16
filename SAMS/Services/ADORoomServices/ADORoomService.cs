namespace SAMS.Services.ADORoomServices
{
    public class ADORoomService : IRoomService
    {
        private ADORoom service;
        public ADORoomService(ADORoom service)
        {
            this.service = service;
        }

        public IEnumerable<Room> GetRooms()
        {
            return service.GetRooms();
        }

        public IEnumerable<Room> GetVacantRooms()
        {
            return service.GetVacantRooms();
        }

        public void UpdateRoom(Room room)
        {
            service.UpdateRoom(room);
        }
    }
}
