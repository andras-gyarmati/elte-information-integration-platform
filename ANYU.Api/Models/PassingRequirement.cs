using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("PassingRequirement")]
public class PassingRequirement
{
    [Key]
    public int RequirementId { get; set; }

    [MaxLength(100)]
    public string Type { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
