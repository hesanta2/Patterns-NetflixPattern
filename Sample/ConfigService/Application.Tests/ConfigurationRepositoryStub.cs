using Common.Infrastructure;
using ConfigService.Domain;
using ConfigService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigService.Application.Tests
{
    public class ConfigurationRepositoryStub : InMemoryRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepositoryStub()
        {
            inMemoryEntities.Clear();
        }

        protected override void Seed(ICollection<Configuration> inMemoryEntities)
        {

        }

        Configuration IConfigurationRepository.Get(string serviceName)
        {
            return this.First(entity => entity.ServiceName == serviceName);
        }
    }
}
