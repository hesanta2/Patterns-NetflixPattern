using Common.Domain;
using System;

namespace ConfigService.Domain
{
    public class Configuration : Entity
    {
        public string ServiceName { get; set; }

        public Configuration(string serviceName)
        {
            this.ServiceName = serviceName;
        }

    }
}
