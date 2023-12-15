using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("CourseInstance")]
public class CourseInstance
{
    [Key]
    public int CourseInstanceId { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }

    [ForeignKey("SemesterId")]
    public Semester Semester { get; set; }

    public ICollection<LectureLab> LectureLabs { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
