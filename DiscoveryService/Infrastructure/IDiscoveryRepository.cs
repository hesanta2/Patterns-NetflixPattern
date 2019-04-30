using Common.Infrastructure;
using DiscoveryService.Domain;
using System;

namespace DiscoveryService.Infrastructure
{
    public interface IDiscoveryRepository : IRepository<DiscoveredInstance>
    {
        DiscoveredInstance Get(string serviceName);
    }
}
