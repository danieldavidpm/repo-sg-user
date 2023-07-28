using Microsoft.AspNetCore.Mvc;
using Negocio.Authorization;

namespace api_user_security.Controllers.Core
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {

    }
}
