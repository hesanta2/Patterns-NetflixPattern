using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using ConfigService.Domain;
using Microsoft.Extensions.Logging;

namespace ConfigServiceClient
{
    public class ConfigurationClient : IConfigurationClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        public string Endpoint { get { return this.httpClient.BaseAddress.ToString(); } }

        public ConfigurationClient(HttpClient httpClient, ILogger<ConfigurationClient> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<Configuration> Get(string serviceName)
        {
            this.logger.LogInformation($"Getting configuration of '{serviceName}' from '{this.Endpoint}'");
            var response = await this.httpClient.GetAsync($"api/{serviceName}");
            var result = await response.Content.ReadAsAsync<Configuration>();

            if (result != null)
                this.logger.LogInformation($"Configuration of '{serviceName}' retrived: {result}");
            else
                this.logger.LogWarning($"Missing configuration of '{serviceName}'");

            return result;
        }
    }
}
