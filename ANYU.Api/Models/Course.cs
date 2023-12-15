using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("Course")]
public class Course
{
    [Key]
    public int CourseId { get; set; }

    [MaxLength(255)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string Code { get; set; } = null!;

    [MaxLength(255)]
    public string Category { get; set; } = null!;

    public int Credit { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    public ICollection<CourseInstance> CourseInstances { get; set; } = new HashSet<CourseInstance>();

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
