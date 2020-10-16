using iot_22990_example1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot_22990_example1.Controllers
{
    [ApiController]
    [Route("api/people")]

    public class PeopleController : ControllerBase
    {
        private List<Person> people;

        public PeopleController()
        {
            people = new List<Person>()
            {
                new Person
                {
                FirstName = "Damian",
                LastName = "Ciszak",
                Id = 1
                },
                new Person
                {
                FirstName = "Jan",
                LastName = "Nowak",
                Id = 2
                }
            };
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(people);
        }
    }
}
