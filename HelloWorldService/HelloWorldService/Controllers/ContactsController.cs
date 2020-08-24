using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticator]
    public class ContactsController : ControllerBase
    {
        public static List<Contact> contacts = new List<Contact>();
        public static int currentId = 101;

        // GET: api/<ContactsController>
        // Retrieve a data/record to the resource
        [HttpGet] // All action in the ContactsController are using HTTP Method
        public IActionResult Get()
        {
            // Handling Error locally
            //try
            //{
            //    int x = 1;
            //    x = x / (x - 1);

            //    return Ok(contacts);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    return new ObjectResult(new ApiResponse(404));
            //}

            return Ok(contacts);
        }

        // GET api/<ContactsController>/5
        // Reframe from changing parameter names. It may be used elsewhere.
        // If you need to rename it, do it inside the method.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }
            return new OkObjectResult(contact);
        }

        [HttpGet]
        [Route("customers/{customerId}/orders")]
        public IActionResult GetCustomer(int customerId)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == customerId);

            if (contact == null)
            {
                return NotFound();
            }
            return new OkObjectResult(contact);
        }

        // POST api/<ContactsController>
        // Add a data/record to the resource
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.Id = currentId++;
            value.DateAdded = DateTime.Now;

            contacts.Add(value);

            // var result = new { Id = value.Id, Candy = true }; not needed.
            // returns a Location Header.

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value); // Returns a 201
        }

        // PUT api/<ContactsController>/5
        // Update a data/record to the resource
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            // contact = value; this way is not as safe, since they can accidentically update all fields in the object.

            contact.Id = id;
            contact.Name = value.Name;
            contact.Phones = value.Phones;

            return Ok(contact);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactsRemoved = contacts.RemoveAll(t => t.Id == id);

            if (contactsRemoved == 0)
            {
                return NotFound(); // Returns a 404
            }

            return Ok(); // Returns a 200
        }
    }
}
