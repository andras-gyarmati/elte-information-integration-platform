using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("User")]
public class User
{
    [Key]
    public int UserId { get; set; }

    public bool IsDeleted { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(255)]
    public string Email { get; set; }

    [MaxLength(255)]
    public string Role { get; set; }

    public int? UniversityId { get; set; }

    [ForeignKey("UniversityId")]
    public University University { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }

    public ICollection<UserCompletedRequirement> CompletedRequirements { get; set; }
}
