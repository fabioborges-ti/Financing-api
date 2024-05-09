using AppGroup.Financing.Application.UseCases.Propostas.Aprovar;
using AppGroup.Financing.Application.UseCases.Propostas.Listar;
using AppGroup.Financing.Application.UseCases.Propostas.Recusar;
using AppGroup.Financing.Domain.Enums;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Financing.API.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PropostaController : ApiControllerBase
{
    [HttpPatch("Aprovar")]
    public async Task<ActionResult<AprovarPropostaResponse>> Aprovar([FromBody] AprovarPropostaRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpPatch("Recusar")]
    public async Task<ActionResult<RecusarPropostaRequest>> Recusar([FromBody] RecusarPropostaRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("Listar")]
    public async Task<ActionResult<ListarPropostasResponse>> Listar(StatusPropostaEnum status)
    {
        var request = new ListarPropostasRequest { Status = status };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
