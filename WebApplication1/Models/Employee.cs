using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Employee")]
public class Employee
{
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        public DateTime HireDate { get; set; }

        private ICollection<Responsible> Responsibles = null!;
}