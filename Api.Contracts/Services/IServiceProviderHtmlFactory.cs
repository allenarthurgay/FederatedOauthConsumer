using Data;

namespace Api.Contracts.Services
{
    public interface IServiceProviderHtmlFactory
    {
        IServiceProviderHtmlService GetProviderHtmlService(ServiceProvider provider);
    }
}
