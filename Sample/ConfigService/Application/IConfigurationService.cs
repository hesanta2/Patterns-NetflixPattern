using ConfigService.Domain;

namespace ConfigService.Application
{
    public interface IConfigurationService
    {
        void AddConfiguration(Configuration configuration);
        Configuration Get(string serviceName);
    }
}