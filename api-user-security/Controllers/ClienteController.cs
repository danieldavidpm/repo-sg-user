using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.ClienteDto;
using Entidades.Dto.RolDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteN _IClienteN;

        public ClienteController(IClienteN IClienteN)
        => _IClienteN = IClienteN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _IClienteN.GetAll();
            return new OkObjectResult(new JsonResult<List<ClienteGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _IClienteN.GetById(id);
            return new OkObjectResult(new JsonResult<ClienteGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ClienteAddDto app)
        {
            var entity = await _IClienteN.AddAsync(app);
            return new OkObjectResult(new JsonResult<ClienteAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ClienteAddDto app)
        {
            var entity = await _IClienteN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<ClienteAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _IClienteN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
