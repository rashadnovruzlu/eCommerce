using eCommerce.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers;

/// <summary>
/// Base controller
/// </summary>
[Route("api/v{v:apiVersion}/[controller]")]
//[Route("api/{culture}/v{v:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class BaseController : ControllerBase
{
    [HttpGet("Test")]
    public ActionResult Test()
    {
        return Ok("Worked !");
    }

    protected const string _hashName = "Hash";

    protected string Encrypt(int? id)
    {
        if (id == null)
            id = 0;

        return TextEncryption.Encrypt(id.ToString());
    }

    protected int Decrypt(string id)
    {
        if (id is null)

            return 0;

        return Convert.ToInt32(TextEncryption.Decrypt(id.ToString()));
    }
}
