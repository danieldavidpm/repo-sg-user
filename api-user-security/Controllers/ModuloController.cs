using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.ModuloDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class ModuloController : ApiController
    {
        private readonly IModuloN _ModuloN;
        public ModuloController(IModuloN IModuloN)
        => _ModuloN = IModuloN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _ModuloN.GetAll();
            return new OkObjectResult(new JsonResult<List<ModuloGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _ModuloN.GetById(id);
            return new OkObjectResult(new JsonResult<ModuloGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ModuloAddDto app)
        {
            var entity = await _ModuloN.AddAsync(app);
            return new OkObjectResult(new JsonResult<ModuloAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ModuloAddDto app)
        {
            var entity = await _ModuloN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<ModuloAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _ModuloN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
