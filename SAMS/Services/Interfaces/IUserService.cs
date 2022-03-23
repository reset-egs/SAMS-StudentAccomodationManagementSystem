namespace SAMS.Services.Interfaces
{
    public interface IUserService
    {
        public void SignUp(string username, string password, int studentNo);
        public User Login(string username, string password);
    }
}
