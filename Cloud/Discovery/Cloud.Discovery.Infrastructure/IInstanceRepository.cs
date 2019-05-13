using System.Collections.Generic;
using Cloud.Shared.Domain;

namespace Cloud.Discovery.Infrastructure
{
    public interface IInstanceRepository
    {
        IEnumerable<Instance> GetByAppId(string appID);
        void Add(Instance instance);
        IEnumerable<Instance> GetAll();
        Instance GetByAppIdInstanceId(string appID, string hostName, int port);
        Instance GetByHostNamePort(string hostName, int port);
    }
}