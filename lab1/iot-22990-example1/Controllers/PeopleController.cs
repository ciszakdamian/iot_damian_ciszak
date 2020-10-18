using iot_22990_example1.Database;
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
        private readonly PeopleDbContext db;

        public PeopleController(PeopleDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.People.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var person = db.People.FirstOrDefault(w => w.Id == id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return Ok(person.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            var person = db.People.Find(id);
            db.Remove(person);
            db.SaveChanges();

            return Ok("Remove");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            db.Update(person);
            db.SaveChanges();
            return Ok(person.Id);
        }


    }
}
