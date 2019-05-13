using Cloud.Discovery.Infrastructure;
using Cloud.Shared.Domain;
using Cloud.Shared.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace DiscoveryService.Application.Tests
{
    [ExcludeFromCodeCoverage]
    public class InstanceRepositoryStub : InMemoryRepository<Instance>, IInstanceRepository
    {
        public InstanceRepositoryStub()
        {
            inMemoryEntities.Clear();
        }

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
