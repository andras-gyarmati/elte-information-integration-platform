using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("UniversityRequirement")]
public class UniversityRequirement
{
    [Key]
    public int RequirementId { get; set; }

    public int UniversityId { get; set; }

    public int CreditsRequired { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [ForeignKey("UniversityId")]
    public University University { get; set; } = null!;

    public List<UniversityRequirementCourse> MandatoryCourses { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
