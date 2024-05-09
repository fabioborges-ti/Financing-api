using System.Text.Json.Serialization;

namespace AppGroup.Financing.Domain.Dtos.Http;

public class RequestBaseDto
{
    [JsonIgnore]
    public bool HasError { get; set; } = false;

    [JsonIgnore]
    public string ErrorMessage { get; set; } = string.Empty;
}
