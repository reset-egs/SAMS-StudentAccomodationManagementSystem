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


        public void UpdateRoom(int place_No)
        {
            service.UpdateRoom(place_No);
        }
    }
}
