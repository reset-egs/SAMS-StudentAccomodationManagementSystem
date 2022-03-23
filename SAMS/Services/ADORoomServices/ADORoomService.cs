namespace SAMS.Services.ADORoomServices
{
    public class ADORoomService : IRoomService
    {
        private ADORoom service;
        public ADORoomService(ADORoom service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await service.GetRoomsAsync();
        }


        public async Task UpdateRoomAsync(int place_No)
        {
            await service.UpdateRoomAsync(place_No);
        }
    }
}
