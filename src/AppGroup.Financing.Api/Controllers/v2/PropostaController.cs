using AppGroup.Financing.Application.UseCases.Propostas.Consultar;
using AppGroup.Financing.Application.UseCases.Propostas.Consultar.Validator;
using AppGroup.Financing.Application.UseCases.Propostas.Criar;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Financing.API.Controllers.v2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PropostaController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CriarPropostaResponse>> Criar([FromBody] CriarPropostaRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("{cpf}")]
    public async Task<ActionResult<ConsultarPropostaResponse>> Criar(string cpf)
    {
        var request = new ConsultarPropostaRequest { Cpf = cpf };

        #region VALIDATOR

        var validator = new ConsultarPropostaValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(c => new { Field = c.PropertyName, Message = c.ErrorMessage }).ToList());

        #endregion

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
