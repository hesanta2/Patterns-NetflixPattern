using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigService.Application;
using ConfigService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ConfigService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ConfigServiceController : ControllerBase
    {
        private IConfigurationService configurationService;

        public ConfigServiceController(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        [HttpGet("{serviceName}")]
        public Configuration Get(string serviceName)
        {
            var configuration = this.configurationService.Get(serviceName);

            return configuration;
        }

        [HttpPost("RegisterDiscoveryService")]
        public Configuration RegisterDiscoveryService(DiscoveryService.Domain.DiscoveredInstance serviceName)
        {
            //var configuration = this.configurationService.Get(serviceName);

            return null;
        }

    }
}