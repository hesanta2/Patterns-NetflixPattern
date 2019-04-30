using ConfigService.Domain;

namespace ConfigService.Application
{
    public interface IConfigurationService
    {
        Configuration Get(string serviceName);
    }
}