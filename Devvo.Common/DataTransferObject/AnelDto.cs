namespace Devvo.Common.DataTransferObject;

public record AnelDto: EntityDto
{
    public required string Nome { get; set; }
    public required string Poder { get; set; }
    public required string Portador { get; set; }
    public required string ForjadoPor { get; set; }
    public required string Imagem { get; set; }
}