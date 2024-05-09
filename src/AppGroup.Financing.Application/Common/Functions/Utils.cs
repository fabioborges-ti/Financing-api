using System.Text.RegularExpressions;

namespace AppGroup.Financing.Application.Common.Functions;

public static class Utils
{
    public static bool BeValidCPF(string cpf)
    {
        // Remove caracteres não numéricos
        cpf = Regex.Replace(cpf, @"\D", "");

        // Verifica se o CPF tem 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais (caso raro)
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcula o primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(cpf[i].ToString()) * (10 - i);
        int resto = soma % 11;
        int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

        // Calcula o segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(cpf[i].ToString()) * (11 - i);
        resto = soma % 11;
        int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

        // Verifica se os dígitos verificadores estão corretos
        return int.Parse(cpf[9].ToString()) == digitoVerificador1 && int.Parse(cpf[10].ToString()) == digitoVerificador2;
    }

    public static bool BeValidCNPJ(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        // Remove caracteres não numéricos do CNPJ
        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        // Verifica se o CNPJ tem 14 dígitos
        if (cnpj.Length != 14)
            return false;

        // Verifica se todos os dígitos são iguais, o que não é permitido para um CNPJ válido
        if (cnpj.Distinct().Count() == 1)
            return false;

        // Calcula os dígitos verificadores
        int[] multipliers1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multipliers2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        // Verifica o primeiro dígito verificador
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            sum += int.Parse(cnpj[i].ToString()) * multipliers1[i];
        }
        int remainder = sum % 11;
        int digit1 = remainder < 2 ? 0 : 11 - remainder;

        if (int.Parse(cnpj[12].ToString()) != digit1)
            return false;

        // Verifica o segundo dígito verificador
        sum = 0;
        for (int i = 0; i < 13; i++)
        {
            sum += int.Parse(cnpj[i].ToString()) * multipliers2[i];
        }
        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        return int.Parse(cnpj[13].ToString()) == digit2;
    }

    public static double CalculateRange(DateTime data1, DateTime data2)
    {
        var days = (data2.Date - data1.Date).Days;

        return days;
    }

    public static decimal CalcularValorParcela(decimal valorEmprestimo, decimal taxaJuros, int numeroParcelas)
    {
        decimal taxa = 1 + taxaJuros;
        decimal parcela = (valorEmprestimo * taxaJuros) / (1 - (decimal)Math.Pow((double)taxa, -numeroParcelas));

        return Math.Round(parcela, 2); // Arredondando para duas casas decimais
    }
}
