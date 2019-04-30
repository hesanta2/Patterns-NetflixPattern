using DiscoveryService.Domain;

namespace DiscoveryService.Application
{
    public interface IDiscoveryService
    {
        void Add(DiscoveredInstance discoveredInstance);
    }
}