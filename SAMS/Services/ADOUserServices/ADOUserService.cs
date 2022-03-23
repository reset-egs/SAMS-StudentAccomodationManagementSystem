namespace SAMS.Services.ADOUserServices
{
    public class ADOUserService : IUserService
    {
        private ADOUser service;
        public ADOUserService(ADOUser service)
        {
            this.service = service;
        }

        public User Login(string username, string password)
        {
            return service.Login(username, password);
        }

        public void SignUp(string username, string password, int studentNo)
        {
            service.SignUp(username, password, studentNo);
        }
    }
}
