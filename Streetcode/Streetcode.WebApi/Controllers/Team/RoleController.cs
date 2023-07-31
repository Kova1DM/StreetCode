using Microsoft.AspNetCore.Mvc;
using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.DTO.Team;
using Streetcode.BLL.MediatR.Team.Create;
using Streetcode.BLL.MediatR.Team.Delete;
using Streetcode.BLL.MediatR.Team.GetAll;
using Streetcode.BLL.MediatR.Team.GetById;
using Streetcode.BLL.MediatR.Team.Update;
using Streetcode.DAL.Enums;
using Streetcode.WebApi.Attributes;

namespace Streetcode.WebApi.Controllers.Team
{
    public class RoleController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllRoleQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new GetByIdRoleQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleCreateDTO role)
        {
            return HandleResult(await Mediator.Send(new CreateRoleQuery(role)));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleDTO role)
        {
            return HandleResult(await Mediator.Send(new UpdateRoleQuery(role)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new DeleteRoleQuery(id)));
        }
    }
}
