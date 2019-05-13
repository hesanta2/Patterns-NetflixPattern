using Common.Domain;
using System;

namespace ConfigService.Domain
{
    public class Configuration : Entity
    {
        public string ServiceName { get; private set; }
        public DiscoveryService DiscoverService { get; private set; }

        public Configuration(string serviceName)
        {
            this.ServiceName = serviceName;
        }

        public void SetDiscoveryService(DiscoveryService discoverService)
        {
            this.DiscoverService = discoverService;
        }

        public override string ToString()
        {
            return $@"{this.GetType()}{{{nameof(ServiceName)}='{this.ServiceName}'}}";
        }
    }
}
