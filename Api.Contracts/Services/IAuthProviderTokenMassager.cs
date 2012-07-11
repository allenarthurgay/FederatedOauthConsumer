using Data;

namespace Api.Contracts.Services
{
    //this allows a 3rd parth auth provider the opportunity to take the "Token" string, parse it into a DTO,
    //and then serialize it into a normalized string
    public interface IAuthProviderTokenMassager
    {
        ServiceProvider SupportedService { get; }

        string NormalizeToken(string serviceAuthToken);
    }
}
