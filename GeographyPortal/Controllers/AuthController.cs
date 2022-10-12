using GeographyPortal.Models;
using GeographyPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeographyPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost(Name = "Registarion")]
        public async Task<ActionResult> Registration(InputModel input)
        {
            try
            {
                await _auth.CreateAsync(input);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        }
    }
}
