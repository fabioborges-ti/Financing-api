namespace AppGroup.Financing.Domain.Entities.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public string? CriadoPor { get; set; }
    public DateTime? ModificadoEm { get; set; }
    public string? ModificadoPor { get; set; }
    public DateTime? ExcluidoEm { get; set; }
    public string? ExcluidoPor { get; set; }
}
