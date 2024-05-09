using AppGroup.Financing.Domain.Dtos.TiposCredito;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace AppGroup.Financing.IntegrationTests.Controllers.v1;

public class CreditoControllerTests
{
    [Fact]
    [Trait($"Controllers - {nameof(CreditoControllerTests)}", "V1")]
    public async Task SearchRent_ShouldResult_BadRequest()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v1/Credito/Tipos", Method.Get);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        var result = JsonConvert.DeserializeObject<List<BuscarTiposCreditoDto>>(response.Content!);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(5, result!.Count);
    }
}
