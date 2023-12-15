using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("Course")]
public class Course
{
    [Key]
    public int CourseId { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Code { get; set; }

    [MaxLength(255)]
    public string Category { get; set; }

    public int Credit { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public ICollection<CourseInstance> CourseInstances { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
