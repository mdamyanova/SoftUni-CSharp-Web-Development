namespace CarDealer.Web.Models.ManageModels
{
    public class TwoFactorAuthenticationModel
    {
        public bool HasAuthenticator { get; set; }

        public int RecoveryCodesLeft { get; set; }

        public bool Is2faEnabled { get; set; }
    }
}