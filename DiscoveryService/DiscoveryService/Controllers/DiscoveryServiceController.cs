using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryService.Application;
using DiscoveryService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DiscoveryService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DiscoveryServiceController : ControllerBase
    {
        private IDiscoveryService DiscoveryService { get; }

        public DiscoveryServiceController(IDiscoveryService discoveryService)
        {
            this.DiscoveryService = discoveryService;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost("add")]
        public void Add([FromBody]string serviceName, string endPoint)
        {
            var discoveredInstance = new DiscoveredInstance(serviceName, new Uri(endPoint));
            this.DiscoveryService.Add(discoveredInstance);
        }


    }
}
