using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.RolOpe;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class RolOpeController : ApiController
    {
        private readonly IRolOpeN _RolOpeN;
        public RolOpeController(IRolOpeN RolOpeN)
        => _RolOpeN = RolOpeN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _RolOpeN.GetAll();
            return new OkObjectResult(new JsonResult<List<RolOpeGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _RolOpeN.GetById(id);
            return new OkObjectResult(new JsonResult<RolOpeGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RolOpeAddDto app)
        {
            var entity = await _RolOpeN.AddAsync(app);
            return new OkObjectResult(new JsonResult<RolOpeAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] RolOpeAddDto app)
        {
            var entity = await _RolOpeN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<RolOpeAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _RolOpeN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
