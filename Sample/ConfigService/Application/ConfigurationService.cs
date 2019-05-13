using ConfigService.Domain;
using ConfigService.Infrastructure;
using System;

namespace ConfigService.Application
{
    public class ConfigurationService : IConfigurationService
    {
        private IConfigurationRepository configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        public Configuration Get(string serviceName)
        {
            var entity = this.configurationRepository.Get(serviceName);

            return entity;
        }

        public void AddConfiguration(Configuration configuration)
        {
            this.configurationRepository.Add(configuration);
        }
    }
}
