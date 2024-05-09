using AppGroup.Financing.Application.Common.Functions;
using FluentValidation;

namespace AppGroup.Financing.Application.UseCases.Clientes.Cadastro.Validator;

public class CadastroClienteValidator : AbstractValidator<CadastroClienteRequest>
{
    public CadastroClienteValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Por favor, informe seu nome.")
            .NotNull().WithMessage("Por favor, informe seu nome.");

        RuleFor(c => c.Cpf)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O CPF é obrigatório.")
            .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
            .Must(Utils.BeValidCPF).WithMessage("CPF inválido.");

        RuleFor(c => c.Uf)
            .NotEmpty().WithMessage("Por favor, informe a UF.")
            .NotNull().WithMessage("Por favor, informe a UF.");

        RuleFor(c => c.Celular)
            .NotEmpty().WithMessage("Por favor, informe o celular.")
            .NotNull().WithMessage("Por favor, informe o celular.");
    }
}
