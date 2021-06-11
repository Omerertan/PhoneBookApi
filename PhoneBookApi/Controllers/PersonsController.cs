using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.DAL.Context;
using PhoneBookApi.DAL.Entities;

namespace PhoneBookApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using var context = new PhoneBookApiContext();
            return Ok( context.Persons.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var context = new PhoneBookApiContext();
            var person = context.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPut]
        public IActionResult Put(Person person)
        {
            using var context = new PhoneBookApiContext();
            var personDb = context.Persons.Find(person.Id);
            if (personDb == null)
            {
                return NotFound();     
            }
            personDb.Name = person.Name;
            personDb.SurName = person.SurName;
            personDb.PhoneNumber = person.PhoneNumber;
            context.Update(personDb);
            context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var context = new PhoneBookApiContext();
            var person = context.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            context.Remove(person);
            context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add(Person person)
        {
            using var context = new PhoneBookApiContext();
            if (person == null)
            {
                return NotFound();
            }
            context.Persons.Add(person);
            context.SaveChanges();
            return Created("", person);
        }
    }
}
