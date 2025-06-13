namespace WebApplication1.Dto;

public class BatchDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    public SpeciesDto Species { get; set; }= null!;
    public List<ResponsibleDto> Responsibles { get; set; } = null!;
}