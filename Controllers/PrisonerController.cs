using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FedTime.Models;


namespace FedTime.Controllers
{
    [Route("api/prisoners")]
    [ApiController]
    public class PrisonerController : ControllerBase
    {
        static List<Prisoner> _prisoners = new List<Prisoner>
        {
            new Prisoner {Id = 1, Name= "Riley" , ChargeAgency = "TBI", Location= "Riverbend"},
            new Prisoner {Id = 2, Name = "Big Pat", ChargeAgency = "FBI",Location = "Turney Ctr"},
            new Prisoner {Id = 3, Name = "C Black", ChargeAgency = "ATF", Location = "DeBerry" }
        };

        //GET /api/prisoners
        [HttpGet]
        public IActionResult GetAllPrisoners()
        {
            return Ok(_prisoners);
        }
    }
}