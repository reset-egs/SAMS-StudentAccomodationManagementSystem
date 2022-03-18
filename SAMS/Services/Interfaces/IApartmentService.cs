namespace SAMS.Interfaces
{
    public interface IApartmentService
    {
        public IEnumerable<Apartment> GetApartments();
        public IEnumerable<Room> GetVacantRooms(int no);
        public Apartment GetApartmentByNo(int no);
    }
}
