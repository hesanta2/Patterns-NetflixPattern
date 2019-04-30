using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddMicroservice.Application;
using Microsoft.AspNetCore.Mvc;

namespace AddMicroservice.Controllers
{
    [Route("")]
    [ApiController]
    public class AddController : ControllerBase
    {
        private readonly IAddService addService;


        public AddController(IAddService addService)
        {
            this.addService = addService;
        }

        // GET api/add/5/5
        [HttpGet("{n1}/{n2}")]
        public ActionResult<decimal> Get(decimal n1, decimal n2)
        {
            var result = this.addService.Add(n1, n2);

            return result;
        }
    }
}
