namespace SAMS.Interfaces
{
    public interface ILeasingService
    {
        public IEnumerable<Leasing> GetLeasings();
        public void CreateLeasing(Leasing leasing);
        public void UpdateLeasing(Leasing leasing);
    }
}
