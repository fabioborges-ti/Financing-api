using AppGroup.Financing.Application.UseCases.TipoCredito.Listar;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Financing.API.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CreditoController : ApiControllerBase
{
    [HttpGet("Tipos")]
    public async Task<ActionResult<TipoCreditoResponse>> Get()
    {
        var request = new TipoCreditoRequest();

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
