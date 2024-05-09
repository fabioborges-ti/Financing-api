using RestSharp;
using System.Net;

namespace AppGroup.Financing.IntegrationTests.Controllers.v2;

public class ClientesControllerTests
{
    [Fact]
    [Trait($"Controllers - {nameof(ClientesControllerTests)}", "V2")]
    public async Task ShouldResult_BadRequest()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v2/Clientes", Method.Post);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var resultExpected = "{\"type\":\"https://tools.ietf.org/html/rfc7231#section-6.5.1\",\"title\":\"One or more validation errors occurred.\",\"status\":400,\"errors\":{\"Cpf\":[\"O CPF deve ter 11 caracteres.\"]}}";

        requestRest.AddJsonBody(new { Nome = "Fabio", Cpf = "123", Uf = "RJ", Celular = "21 3333.6654" });

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal(resultExpected, response.Content);
    }
}
