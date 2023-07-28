using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.RolDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class RolController : ApiController
    {
        private readonly IRolN _IRolN;
        public RolController(IRolN IRolN)
        => _IRolN = IRolN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _IRolN.GetAll();
            return new OkObjectResult(new JsonResult<List<RolGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _IRolN.GetById(id);
            return new OkObjectResult(new JsonResult<RolGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RolAddDto app)
        {
            var entity = await _IRolN.AddAsync(app);
            return new OkObjectResult(new JsonResult<RolAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] RolAddDto app)
        {
            var entity = await _IRolN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<RolAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _IRolN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
