using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("University")]
public class University
{
    [Key]
    public int UniversityId { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [MaxLength(500)]
    public string Address { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<UniversityRequirement> UniversityRequirements { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
