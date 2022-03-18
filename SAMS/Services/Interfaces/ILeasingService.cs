namespace SAMS.Interfaces
{
    public interface ILeasingService
    {
        public IEnumerable<Leasing> GetLeasings();
        public void CreateLeasing(int place_No, Leasing l);
        public void UpdateLeasing(Leasing leasing);
    }
}
