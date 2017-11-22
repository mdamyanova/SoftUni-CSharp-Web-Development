namespace CameraBazaar.Services.Contracts
{
    using Models.Profile;

    public interface IProfileService
    {
        ProfileViewModel Show();
        void ChangeEmail(string email);
        void ChangePhone(string phone);
        void ChangePassword(string password);
    }
}