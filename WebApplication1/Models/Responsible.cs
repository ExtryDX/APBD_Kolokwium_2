using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Responsible")]
[PrimaryKey(nameof(BatchID), nameof(EmployeeID))]
public class Responsible
{
    [ForeignKey(nameof(SeedlingBatch))]
    public int BatchID { get; set; }
    
    [ForeignKey(nameof(Employee))]
    public int EmployeeID { get; set; }

    [StringLength(100)] 
    public string Role { get; set; } = null!;
    
    public SeedlingBatch SeedlingBatch { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
    
}