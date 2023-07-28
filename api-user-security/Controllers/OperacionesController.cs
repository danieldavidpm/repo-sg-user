using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.OperacionesDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class OperacionesController : ApiController
    {
        private readonly IOperacionesN _OperacionesN;
        public OperacionesController(IOperacionesN IOperacionesN)
        => _OperacionesN = IOperacionesN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _OperacionesN.GetAll();
            return new OkObjectResult(new JsonResult<List<OperacionesGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _OperacionesN.GetById(id);
            return new OkObjectResult(new JsonResult<OperacionesGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] OperacionesAddDto app)
        {
            var entity = await _OperacionesN.AddAsync(app);
            return new OkObjectResult(new JsonResult<OperacionesAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] OperacionesAddDto app)
        {
            var entity = await _OperacionesN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<OperacionesAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _OperacionesN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
