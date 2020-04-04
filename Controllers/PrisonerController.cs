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

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            return Ok(_prisoners);
        }
    
        [HttpGet ("{id}")]
        public IActionResult GetSinglePrisoner(int id)
        {
            var inmateIWant = _prisoners.FirstOrDefault(inmate => inmate.Id == id);

            if (inmateIWant == null)
            {
                return NotFound($"Prisoner with the id {id} was released");
            }
            return Ok(inmateIWant);
        }

        //POST /api/prisoners
        [HttpPost]
        public IActionResult AddPrisoner(Prisoner prisonerToAdd)
        {
            _prisoners.Add(prisonerToAdd);

            return Ok(_prisoners);
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateAnPrisoner(int id, Prisoner prisoner)
        {
           var prisonerToUpdate = _prisoners.FirstOrDefault(prisoner => prisoner.Id == id);

           if(prisonerToUpdate == null)
            {
                return NotFound("Can't Update cause it does not exist");
            }
            prisonerToUpdate.Id = prisoner.Id;
            prisonerToUpdate.Name = prisoner.Name;
            prisonerToUpdate.ChargeAgency = prisoner.ChargeAgency;
            prisonerToUpdate.Location = prisoner.Location;

            return Ok(prisonerToUpdate);
        }
    }
}