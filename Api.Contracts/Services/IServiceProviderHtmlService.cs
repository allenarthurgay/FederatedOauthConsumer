using Data;

namespace Api.Contracts.Services
{
    public interface IServiceProviderHtmlService
    {
        ServiceProvider SupportedService { get; }

        string GetHtmlForService(ServiceProvider provider);
    }
}
