using Common.Infrastructure;
using ConfigService.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace ConfigService.Infrastructure
{
    public class ConfigurationRepository : InMemoryRepository<Configuration>, IConfigurationRepository
    {
        public Configuration Get(string serviceName)
        {
            var entity = First(e => e.ServiceName == serviceName);

            return entity;
        }

        protected override void Seed(ICollection<Configuration> inMemoryEntities)
        {
            inMemoryEntities.Add(new Configuration("DiscoveryService"));
        }
    }
}
