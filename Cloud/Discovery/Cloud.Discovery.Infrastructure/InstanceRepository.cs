using Cloud.Shared.Domain;
using Cloud.Shared.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Cloud.Discovery.Infrastructure
{
    public class InstanceRepository : InMemoryRepository<Instance>, IInstanceRepository
    {
        public IEnumerable<Instance> GetAll()
        {
            return Get();
        }

        public Instance GetByHostNamePort(string hostName, int port)
        {
            return inMemoryEntities.FirstOrDefault
                (
                    entity => 
                        entity.HostName == hostName &&
                        entity.Port == port
                );
        }

        public IEnumerable<Instance> GetByAppId(string appID)
        {
            return inMemoryEntities.Where(entity => entity.App == appID);
        }

        public Instance GetByAppIdInstanceId(string appID, string hostName, int port)
        {
            return inMemoryEntities.FirstOrDefault
                (
                    entity => 
                        entity.App == appID &&
                        entity.HostName == hostName &&
                        entity.Port == port
                );
        }

 
        protected override void Seed(ICollection<Instance> inMemoryEntities)
        {
        }
    }
}
