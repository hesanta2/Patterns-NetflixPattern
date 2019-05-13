using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Cloud.Discovery.Application;
using Cloud.Shared.Web.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Discovery.Server.Controllers
{
    [Route("apps/")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class AppsController : ControllerBase
    {
        private readonly IInstanceService instanceService;


        public AppsController(IInstanceService instanceService)
        {
            this.instanceService = instanceService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Instance>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Instance>> GetAll()
        {
            var instances = this.instanceService.GetAll();

            return instances.Select(instance => (Instance)instance).ToList();
        }

        [HttpGet("{appID}")]
        [ProducesResponseType(typeof(IEnumerable<Instance>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Instance>> GetByAppID(string appID)
        {
            var instances = this.instanceService.GetByAppID(appID);

            return instances.Select(instance => (Instance)instance).ToList();
        }

        [HttpGet("{appID}/{instanceID}")]
        [ProducesResponseType(typeof(IEnumerable<Instance>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Instance> Get(string appID, string instanceID)
        {
            var instance = this.instanceService.GetByAppIdInstanceId(appID, instanceID);
            if (instance == null) return NotFound();

            return (Instance)instance;
        }

        [HttpGet("{instanceID}")]
        [ProducesResponseType(typeof(IEnumerable<Instance>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Instance> GetByInstanceID(string instanceID)
        {
            var instance = this.instanceService.GetByInstanceID(instanceID);
            if (instance == null) return NotFound();

            return (Instance)instance;
        }

        [HttpPost("{appID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Register(string appID, Instance instance)
        {
            if (appID != instance.App)
                throw new ArgumentException($"The argument 'appID'[{appID}] should be equals to parameter 'instance.App'[{instance.App}].");

            this.instanceService.Register(instance);

            return NoContent();
        }

        [HttpPut("{appID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Heartbeat(string appID, string instanceID)
        {
            var instance = this.instanceService.GetByAppIdInstanceId(appID, instanceID);
            if (instance == null) return NotFound();

            this.instanceService.Heartbeat(instanceID);

            return NoContent();
        }


    }
}
