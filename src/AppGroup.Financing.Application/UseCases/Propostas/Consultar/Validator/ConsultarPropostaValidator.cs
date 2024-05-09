using AppGroup.Financing.Application.Common.Functions;
using FluentValidation;

namespace AppGroup.Financing.Application.UseCases.Propostas.Consultar.Validator;

public class ConsultarPropostaValidator : AbstractValidator<ConsultarPropostaRequest>
{
    public ConsultarPropostaValidator()
    {
        RuleFor(c => c.Cpf)
            .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
            .Matches("^[0-9]*$").WithMessage("O número do CPF deve conter apenas dígitos numéricos.")
            .Must(Utils.BeValidCPF).WithMessage("CPF inválido.");
    }
}
