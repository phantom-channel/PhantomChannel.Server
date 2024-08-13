using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhantomChannel.Server.Api.Models;


namespace PhantomChannel.Server.Api.Controllers;

[ApiController]
[EnableCors("AllowedHosts")]
[Route("api/[controller]/[action]")]
public class RSAController(
) : ControllerBase
{


    /// <summary>
    ///  测试接口
    /// </summary>
    /// <returns>Test APi</returns>
    [Authorize(Roles = "User,Admin")]
    [HttpGet()]
    public ActionResult<ApiResponse<string>> TestHello()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        var sub = User.Claims.FirstOrDefault(c => c.Type == "Sub")?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        var res = new ApiResponse<string>(sub ?? string.Empty);

        return Ok(res);
    }

}

