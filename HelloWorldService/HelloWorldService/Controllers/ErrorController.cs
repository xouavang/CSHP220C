using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error/{code}")]
        [HttpGet]
        public IActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
    }
}
