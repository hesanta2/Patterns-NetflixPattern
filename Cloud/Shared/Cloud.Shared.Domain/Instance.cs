using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Shared.Domain
{
    public class Instance : Entity
    {
        public long StartTimestamp { get; protected set; }
        public long HeartbeatTimestamp { get; protected set; }
        public string HostName { get; protected set; }
        public string App { get; protected set; }
        public string IpAddr { get; protected set; }
        public string Status { get; protected set; }
        public int Port { get; protected set; }
        public string HealthCheckUrl { get; protected set; }
        public string StatusPageUrl { get; protected set; }
        public string HomePageUrl { get; protected set; }

        public Instance(string hostName, string app, string ipAddr, string status, int port, string healthCheckUrl, string statusPageUrl, string homePageUrl)
        {
            HostName = hostName ?? throw new ArgumentNullException(nameof(hostName));
            App = app ?? throw new ArgumentNullException(nameof(app));
            IpAddr = ipAddr ?? throw new ArgumentNullException(nameof(ipAddr));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Port = port;
            HealthCheckUrl = healthCheckUrl ?? throw new ArgumentNullException(nameof(healthCheckUrl));
            StatusPageUrl = statusPageUrl ?? throw new ArgumentNullException(nameof(statusPageUrl));
            HomePageUrl = homePageUrl ?? throw new ArgumentNullException(nameof(homePageUrl));
            HeartbeatTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            StartTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public void RenewHeartbeat()
        {
            this.HeartbeatTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        public void SetHeartbeat(long timestamp)
        {
            this.HeartbeatTimestamp = timestamp;
        }
    }
}
