using Cloud.Shared.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Cloud.Discovery.Application
{
    public interface IInstanceService
    {
        IEnumerable<Shared.Domain.Instance> GetByAppID(string appID);
        void Register(Shared.Domain.Instance instance);
        IEnumerable<Shared.Domain.Instance> GetAll();
        Instance GetByAppIdInstanceId(string appID, string instanceID);
        Instance GetByInstanceID(string instanceID);
        void Heartbeat(string instanceID);
    }
}