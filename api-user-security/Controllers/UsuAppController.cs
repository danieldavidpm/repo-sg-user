using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.UsuAppDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class UsuAppController : ApiController
    {
        private readonly IUsuAppN _UsuAppN;
        public UsuAppController(IUsuAppN UsuAppN)
        => _UsuAppN = UsuAppN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _UsuAppN.GetAll();
            return new OkObjectResult(new JsonResult<List<UsuAppGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _UsuAppN.GetById(id);
            return new OkObjectResult(new JsonResult<UsuAppGetAllDto?>(entity));
        }

        [HttpGet("AplicacionesXusu/{id}")]
        public async Task<IActionResult> GetAppsByIdUse(int id)
        {
            var lst = await _UsuAppN.GetAppsByIdUse(id);
            return new OkObjectResult(new JsonResult<List<UsuAppGetAppsXUsuDto?>>(lst));
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UsuAppAddDto app)
        {
            var entity = await _UsuAppN.AddAsync(app);
            return new OkObjectResult(new JsonResult<UsuAppAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsuAppAddDto app)
        {
            var entity = await _UsuAppN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<UsuAppAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _UsuAppN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
