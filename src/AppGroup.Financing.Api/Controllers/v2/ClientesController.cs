using AppGroup.Financing.Application.UseCases.Clientes.Cadastro;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Financing.API.Controllers.v2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ClientesController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CadastroClienteResponse>> Post(CadastroClienteRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : CreatedAtAction(nameof(Post), result.Data);
    }
}
