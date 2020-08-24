using HelloWorldService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldService.Controllers
{
    public class TokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // Both way to get a token. POST and GET

        // This should require SSL
        [HttpPost]
        public IActionResult Post([FromBody] TokenRequest tokenRequest)
        {
            var token = TokenHelper.GetToken(tokenRequest.UserName, tokenRequest.Password);
            return Ok(new Models.Token{ TokenString = token });
        }

        // This should require SSL
        [HttpGet] // URL Binding. Passing in parameters. ".../api/token?userName=dave&password=password". Not RESTful.
        // [Route("{userName}/{password}")] Attribute Routing . ".../api/token/dave/password". More RESTful. But parameters cannot have special characters, i.e. '&', '/', etc.
        public dynamic Get(string userName, string password)
        {
            var token = TokenHelper.GetToken(userName, password);
            return new { Token = token };
        }
    }
}