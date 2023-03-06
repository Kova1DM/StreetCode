using Microsoft.AspNetCore.Mvc;
using Streetcode.BLL.DTO.Streetcode;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.Delete;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.DeleteSoft;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAll;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetById;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetByIndex;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.UpdateStatus;
using Streetcode.DAL.Enums;

namespace Streetcode.WebApi.Controllers.Streetcode;

public class StreetcodeController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllStreetcodesQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetStreetcodeByIdQuery(id)));
    }

    [HttpGet("{index}")]
    public async Task<IActionResult> GetByIndex([FromRoute] int index)
    {
        return HandleResult(await Mediator.Send(new GetStreetcodeByIndexQuery(index)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StreetcodeDTO streetcode)
    {
        // TODO implement here
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StreetcodeDTO streetcode)
    {
        // TODO implement here
        return Ok();
    }

    [HttpPatch("{id:int}/{stage}")]
    public async Task<IActionResult> PatchStage(
        [FromRoute] int id,
        [FromRoute] StreetcodeStatus status)
    {
        return HandleResult(await Mediator.Send(new UpdateStatusStreetcodeByIdCommand(id, status)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> SoftDelete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteSoftStreetcodeCommand(id)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteStreetcodeCommand(id)));
    }
}