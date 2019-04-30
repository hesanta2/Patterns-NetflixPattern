using DiscoveryService.Domain;
using DiscoveryService.Infrastructure;
using System;

namespace DiscoveryService.Application
{
    public class DiscoveryService : IDiscoveryService
    {
        private IDiscoveryRepository discoveryRepository;

        public DiscoveryService(IDiscoveryRepository discoveryRepository)
        {
            this.discoveryRepository = discoveryRepository;
        }

        public void Add(DiscoveredInstance discoveredInstance)
        {
            this.discoveryRepository.Add(discoveredInstance);
        }

        public DiscoveredInstance Get(string serviceName)
        {
            var discoveredInstance = this.discoveryRepository.Get(serviceName);

            return discoveredInstance;
        }
    }
}
