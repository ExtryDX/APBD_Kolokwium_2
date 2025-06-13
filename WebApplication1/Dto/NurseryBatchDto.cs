namespace WebApplication1.Dto;

public class NurseryBatchDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime EstablishDate { get; set; }
    public List<BatchDto> Batches { get; set; } = null!;
}