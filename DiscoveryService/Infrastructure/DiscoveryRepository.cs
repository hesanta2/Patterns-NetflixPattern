using Common.Infrastructure;
using DiscoveryService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoveryService.Infrastructure
{
    public class DiscoveryRepository : InMemoryRepository<DiscoveredInstance>, IDiscoveryRepository
    {
        public DiscoveredInstance Get(string serviceName)
        {
            var entity = this.First(e => e.Name == serviceName);

            return entity;
        }

        protected override void Seed(ICollection<DiscoveredInstance> inMemoryEntities)
        {

        }
    }
}
