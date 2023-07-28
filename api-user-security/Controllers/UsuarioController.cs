using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.UsuarioDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Authorization;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{    
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioN _IUsuarioN;
        public UsuarioController(IUsuarioN IUsuarioN)
        => _IUsuarioN = IUsuarioN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _IUsuarioN.GetAll();
            return new OkObjectResult(new JsonResult<List<UsuarioGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _IUsuarioN.GetById(id);
            return new OkObjectResult(new JsonResult<UsuarioGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UsuarioAddDto app)
        {
            var entity = await _IUsuarioN.AddAsync(app);
            return new OkObjectResult(entity);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsuarioAddDto app)
        {
            var entity = await _IUsuarioN.UpdateAsync(app);
            return new OkObjectResult(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _IUsuarioN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }

        //[HttpDelete("{email}")]
        //public async Task<IActionResult> getLogin([FromBody] AuthenticateLoginDto dto)
        //{
        //    var entity = await _IUsuarioN.GetByLogin(dto);
        //    return new OkObjectResult(new JsonResult<AuthenticateDto>(entity));
        //}

    }
}
