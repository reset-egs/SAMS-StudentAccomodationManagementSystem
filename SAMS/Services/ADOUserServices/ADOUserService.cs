namespace SAMS.Services.ADOUserServices
{
    public class ADOUserService : IUserService
    {
        private ADOUser service;
        public ADOUserService(ADOUser service)
        {
            this.service = service;
        }

        public async Task<Message> GetMessageAsync(string username)
        {
            return await service.GetMessageAsync(username);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await service.LoginAsync(username, password);
        }

        public async Task SignUpAsync(string username, string password, int studentNo)
        {
            await service.SignUpAsync(username, password, studentNo);
        }
    }
}
