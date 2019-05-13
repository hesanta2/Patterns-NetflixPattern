using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Discovery.Application
{
    public class InstanceID
    {
        public string HostName { get; internal set; }
        public int Port { get; internal set; }
        public string InstanceId { get { return $"{HostName}:{Port}"; } }

        public InstanceID(string instanceId)
        {
            var instanceIdKeyValuePair = this.ExtractInstanceId(instanceId);
            this.HostName = instanceIdKeyValuePair.Key;
            this.Port = instanceIdKeyValuePair.Value;
        }

        public InstanceID(string hostName, int port)
        {
            HostName = hostName ?? throw new ArgumentNullException(nameof(hostName));
            Port = port;
        }

        private KeyValuePair<string, int> ExtractInstanceId(string instanceId)
        {
            var instanceIdTokens = instanceId.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            if (instanceIdTokens.Length != 2)
                throw new ArgumentException($"Incorrect format of {nameof(instanceId)} parameter. Should be 'hostname:port'", nameof(instanceId));

            string hostname = instanceIdTokens[0];
            int port;
            try { port = int.Parse(instanceIdTokens[1]); }
            catch (FormatException ex) { throw new FormatException($"The second part of '{nameof(instanceId)}', port should be integer number", ex); }

            return new KeyValuePair<string, int>(hostname, port);
        }
    }
}
