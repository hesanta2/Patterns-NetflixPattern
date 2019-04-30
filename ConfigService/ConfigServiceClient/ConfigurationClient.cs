using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using ConfigService.Domain;

namespace ConfigServiceClient
{
    public class ConfigurationClient : IConfigurationClient
    {
        private readonly HttpClient httpClient;

        public ConfigurationClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5010/");

            this.httpClient = httpClient;
        }

        public async Task<Configuration> Get(string serviceName)
        {
            var response = await this.httpClient.GetAsync($"api/{serviceName}");

            var result = await response.Content.ReadAsAsync<Configuration>();

            return result;
        }
    }
}
