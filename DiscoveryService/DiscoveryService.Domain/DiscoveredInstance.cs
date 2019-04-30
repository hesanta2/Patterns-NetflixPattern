using Common.Domain;
using System;

namespace DiscoveryService.Domain
{
    public class DiscoveredInstance : Entity
    {
        public string Name { get; private set; }
        public Uri Endpoint { get; private set; }


        public DiscoveredInstance(string name, Uri endpoint)
        {
            this.Name = name;
            this.Endpoint = endpoint;
        }
    }
}
