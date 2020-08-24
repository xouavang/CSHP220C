using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTWebService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>();

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return new OkObjectResult(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null || string.IsNullOrEmpty(value.Email) || string.IsNullOrEmpty(value.Password))
            {
                return new BadRequestResult();
            }

            value.Id = Guid.NewGuid();
            value.DateAdded = DateTime.Now;

            users.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User value)
        {
            var user = users.FirstOrDefault(t => t.Id.Equals(id));

            if (user == null)
            {
                return NotFound();
            }

            user.Id = id;
            user.Email = value.Email;
            user.Password = value.Password;
            
            return Ok(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var usersRemoved = users.RemoveAll(t => t.Id.Equals(id));

            if (usersRemoved == 0)
            {
                return NotFound(); // Returns a 404
            }

            return Ok(); // Returns a 200
        }
    }
}
