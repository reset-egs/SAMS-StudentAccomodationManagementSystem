namespace SAMS.Services.ADOApartmentServices
{
    public class ADOApartmentService : IApartmentService
    {
        private ADOApartment service;
        public ADOApartmentService(ADOApartment service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<Apartment>> GetApartmentsAsync()
        {
            return await service.GetApartmentsAsync();
        }

        public async Task<Apartment> GetApartmentByNoAsync(int no)
        {
            return await service.GetApartmentByNoAsync(no);
        }

        public async Task<IEnumerable<Room>> GetVacantRoomsAsync(int no)
        {
            return await service.GetVacantRoomsAsync(no);
        }
    }
}
