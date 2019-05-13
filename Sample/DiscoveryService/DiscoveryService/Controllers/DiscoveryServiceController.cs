/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryService.Application;
using DiscoveryService.Domain;
using DiscoveryService.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscoveryService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DiscoveryServiceController : ControllerBase
    {
        private IDiscoveryService discoveryService;

        public DiscoveryServiceController(IDiscoveryService discoveryService)
        {
            this.discoveryService = discoveryService;
        }

        [HttpGet("{serviceName}")]
        [ProducesResponseType(typeof(DiscoveredInstanceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DiscoveredInstanceDto> Get(string serviceName)
        {
            var discoveryInstance = this.discoveryService.Get(serviceName);

            if (discoveryInstance == null) return NotFound();

            var dto = (DiscoveredInstanceDto)discoveryInstance;

            return dto;
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(DiscoveredInstanceDto), StatusCodes.Status201Created)]
        public IActionResult Add([FromBody]DiscoveredInstanceDto discoveredInstance)
        {
            DiscoveredInstance entity = discoveredInstance;
            this.discoveryService.Add(entity);

            discoveredInstance.Id = entity.Id;

            return CreatedAtAction(nameof(Get), new { serviceName = discoveredInstance.Name }, discoveredInstance);
        }


    }
}*/
