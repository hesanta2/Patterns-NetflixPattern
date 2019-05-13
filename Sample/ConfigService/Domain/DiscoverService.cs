using Common.Domain;
using System;

namespace ConfigService.Domain
{
    public class DiscoveryService : Entity
    {
        public string Name { get; set; }

        public DiscoveryService(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $@"{this.GetType()}{{{nameof(Name)}='{this.Name}'}}";
        }
    }
}
