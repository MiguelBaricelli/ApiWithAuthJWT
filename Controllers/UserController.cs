using ApiWithTokenJWT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithTokenJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    
    [Authorize]
    [HttpGet]
    public ActionResult<Response<string>> GetUser()
    {
        Response<string> response = new Response<string>();

        response.Message = "Accepted";

        return Ok(response);
    }
}