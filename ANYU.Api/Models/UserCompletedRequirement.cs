using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("UserCompletedRequirement")]
public class UserCompletedRequirement
{
    [Key, Column(Order = 0)]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    public int RequirementId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("RequirementId")]
    public PassingRequirement PassingRequirement { get; set; }
}
