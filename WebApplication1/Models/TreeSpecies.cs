using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Tree_Species")]
public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    
    [StringLength(100)]
    public string LatinName { get; set; } = null!;
    
    public int GrowthTimeInYears { get; set; }
}