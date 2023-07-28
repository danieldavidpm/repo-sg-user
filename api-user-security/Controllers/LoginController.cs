using api_user_security.Controllers.Core;
using Entidades.Dto.UsuarioDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioN _IUsuarioN;
        public LoginController(IUsuarioN IUsuarioN)
        => _IUsuarioN = IUsuarioN;

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var result = "El Index de Login";
            return new OkObjectResult(result);
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AddAsync([FromBody] AuthenticateLoginDto dto) =>
           new OkObjectResult(await _IUsuarioN.GetAuthenticate(dto));

    }
}
