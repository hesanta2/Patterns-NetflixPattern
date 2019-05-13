using System;
using System.Collections.Generic;
using Cloud.Discovery.Infrastructure;
using Cloud.Shared.Domain;
using Microsoft.Extensions.Logging;

namespace Cloud.Discovery.Application
{
    public class InstanceService : IInstanceService
    {
        private readonly IInstanceRepository instanceRepository;
        private readonly ILogger<InstanceService> logger;

        public InstanceService(IInstanceRepository instanceRepository, ILogger<InstanceService> logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
        }

        public IEnumerable<Shared.Domain.Instance> GetAll()
        {
            return this.instanceRepository.GetAll();
        }

        public IEnumerable<Shared.Domain.Instance> GetByAppID(string appID)
        {
            var instance = this.instanceRepository.GetByAppId(appID);
            logger.LogInformation("Getting Instance with appId ({@appID}), instance {@instance}", appID, instance);

            return instance;
        }

        public Instance GetByAppIdInstanceId(string appID, string instanceID)
        {
            var instanceIDObject = new InstanceID(instanceID);
            return this.instanceRepository.GetByAppIdInstanceId(appID, instanceIDObject.HostName, instanceIDObject.Port);
        }

        public Instance GetByInstanceID(string instanceID)
        {
            var instanceIDObject = new InstanceID(instanceID);
            return this.instanceRepository.GetByHostNamePort(instanceIDObject.HostName, instanceIDObject.Port);
        }

        public void Heartbeat(string instanceID)
        {
            var instanceIDObject = new InstanceID(instanceID);
            var instance = this.instanceRepository.GetByHostNamePort(instanceIDObject.HostName, instanceIDObject.Port);
            if (instance == null) throw new InvalidOperationException($"The instance '{instanceID}' doesn't exist");

            instance.RenewHeartbeat();
        }

        public void Register(Shared.Domain.Instance instance)
        {
            string appId = instance.App;
            var instanceIDObject = new InstanceID(instance.HostName, instance.Port);
            var instanceId = instanceIDObject.InstanceId;

            var existingInstance = this.GetByAppIdInstanceId(appId, instanceId);
            if (existingInstance != null)
                throw new InvalidOperationException($"The application '{appId}' has instance '{instanceId}' already registered ");

            this.instanceRepository.Add(instance);
        }
    }
}
