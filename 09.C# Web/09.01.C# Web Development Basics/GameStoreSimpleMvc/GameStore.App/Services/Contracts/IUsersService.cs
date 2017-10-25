namespace GameStore.App.Services.Contracts
{
    public interface IUsersService
    {
        bool Create(string email, string password, string name);

        bool UserExists(string email, string password);
    }
}