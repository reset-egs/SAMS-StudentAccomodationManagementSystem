namespace SAMS.Interfaces
{
    public interface IApartmentService
    {
        public Task<IEnumerable<Apartment>> GetApartmentsAsync();
        public Task<IEnumerable<Room>> GetVacantRoomsAsync(int no);
        public Task<Apartment> GetApartmentByNoAsync(int no);
    }
}
