namespace SAMS.Services.Interfaces
{
    public interface IUserService
    {
        public Task SignUpAsync(string username, string password, int studentNo);
        public Task<User> LoginAsync(string username, string password);
        public Task<Message> GetMessageAsync(string username);
    }
}
