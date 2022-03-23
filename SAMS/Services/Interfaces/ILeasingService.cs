namespace SAMS.Interfaces
{
    public interface ILeasingService
    {
        public Task<IEnumerable<Leasing>> GetLeasingsAsync();
        public Task CreateLeasingAsync(int place_No, Leasing l);
    }
}
