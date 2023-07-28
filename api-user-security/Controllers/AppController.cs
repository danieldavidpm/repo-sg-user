using api_user_security.Controllers.Core;
using Common;
using Entidades.Dto.AppDto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace api_user_security.Controllers
{
    public class AppController : ApiController
    {
        private readonly IAppN _appN;
        public AppController(IAppN appN)
        => _appN = appN;

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var lst = await _appN.GetAll();
            return new OkObjectResult(new JsonResult<List<AppGetAllDto>>(lst));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _appN.GetById(id);
            return new OkObjectResult(new JsonResult<AppGetAllDto?>(entity));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AppAddDto app)
        {
            var entity = await _appN.AddAsync(app);
            return new OkObjectResult(new JsonResult<AppAddDto>(entity));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AppAddDto app)
        {
            var entity = await _appN.UpdateAsync(app);
            return new OkObjectResult(new JsonResult<AppAddDto>(app));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _appN.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(entity));
        }
    }
}
