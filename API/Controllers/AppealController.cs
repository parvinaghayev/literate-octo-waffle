using System.Net;
using API.Controllers.Commons;
using Application.Features.Appls.Appeals.Commands.CreateAppeal;
using Application.Features.Appls.Appeals.Commands.DeleteAppeal;
using Application.Features.Appls.Appeals.Commands.UpdateAppeal;
using Application.Features.Appls.Appeals.Dtos.GetAllAppeals;
using Application.Features.Appls.Appeals.Queries.GetAllAppeals;
using Application.Features.Appls.Appeals.Queries.GetAppealById;
using Application.Features.Appls.Appeals.Requests.CreateAppeal;
using Application.Features.Appls.Appeals.Requests.UpdateAppeal;
using Application.Routes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AppealController : BaseController
{
    [HttpGet(ApiRoutes.AppealRoute.GetAll)]
    [ProducesResponseType(typeof(GetAllAppealsQueryResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll([FromQuery] int size, int index,
        [FromQuery] AppealFilter appealFilter)
        => Ok(await Sender.Send(new GetAllAppealsQuery(size, index, appealFilter)));

    [HttpGet(ApiRoutes.AppealRoute.GetById)]
    [ProducesResponseType(typeof(GetAppealByIdQueryResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int id)
        => Ok(await Sender.Send(new GetAppealByIdQuery(id)));

    [HttpPost(ApiRoutes.AppealRoute.Create)]
    [ProducesResponseType(typeof(CreateAppealCommandResponse), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create([FromBody] CreateAppealRequest createAppealRequest)
    {
        var response = await Sender.Send(new CreateAppealCommand(createAppealRequest));
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPut(ApiRoutes.AppealRoute.Update)]
    [ProducesResponseType(typeof(UpdateAppealCommandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAppealRequest updateAppealRequest)
    {
        var response = await Sender.Send(new UpdateAppealCommand(id, updateAppealRequest));
        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete(ApiRoutes.AppealRoute.Delete)]
    [ProducesResponseType(typeof(DeleteAppealCommandResponse), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await Sender.Send(new DeleteAppealCommand(id));
        return NoContent();
    }
}