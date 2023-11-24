using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)]
    public string Name { get; set; } = null!;

    [MaxLength(255)]
    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
