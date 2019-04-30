using Common.Infrastructure;
using ConfigService.Domain;

namespace ConfigService.Infrastructure
{
    public interface IConfigurationRepository : IRepository<Configuration>
    {
        Configuration Get(string serviceName);
    }
}