using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto;

public class BatchPostDto
{

    public int Quantity { get; set; }
    [StringLength(100)]
    public string Species { get; set; } = null!;
    [StringLength(100)]
    public string Nursery { get; set; } = null!;
    public List<ResponsibleDto> Responsibles { get; set; } = null!;

}