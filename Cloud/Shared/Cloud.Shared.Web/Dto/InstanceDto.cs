using Cloud.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Cloud.Shared.Web.Dto
{
    [ExcludeFromCodeCoverage]
    public class Instance
    {
        public string HostName { get; set; }
        public string App { get; set; }
        public string IpAddr { get; set; }
        public string Status { get; set; }
        public int Port { get; set; }
        public string HealthCheckUrl { get; set; }
        public string StatusPageUrl { get; set; }
        public string HomePageUrl { get; set; }


        public static implicit operator Domain.Instance(Instance dto)
        {
            if (dto == null) return null;

            return new Domain.Instance
            (
                dto.HostName,
                dto.App,
                dto.IpAddr,
                dto.Status,
                dto.Port,
                dto.HealthCheckUrl,
                dto.StatusPageUrl,
                dto.HomePageUrl
            );
        }

        public static implicit operator Instance(Domain.Instance entity)
        {
            if (entity == null) return null;

            return new Instance
            {
                HostName = entity.HostName,
                App = entity.App,
                IpAddr = entity.IpAddr,
                Status = entity.Status,
                Port = entity.Port,
                HealthCheckUrl = entity.HealthCheckUrl,
                StatusPageUrl = entity.StatusPageUrl,
                HomePageUrl = entity.HomePageUrl
            };

        }
    }
}
