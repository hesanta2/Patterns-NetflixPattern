using ConfigService.Domain;
using System.Threading.Tasks;

namespace ConfigServiceClient
{
    public interface IConfigurationClient
    {
        Task<Configuration> Get(string serviceName);
    }
}