using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("LectureLab")]
public class LectureLab
{
    [Key]
    public int LectureLabId { get; set; }

    public int CourseInstanceId { get; set; }

    [MaxLength(100)]
    public string Type { get; set; } = null!;

    [MaxLength(100)]
    public string Code { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int TeacherId { get; set; }

    [MaxLength(255)]
    public string Location { get; set; } = null!;

    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [ForeignKey("CourseInstanceId")]
    public CourseInstance CourseInstance { get; set; } = null!;

    [ForeignKey("TeacherId")]
    public User Teacher { get; set; } = null!;

    public ICollection<LectureLabPrerequisite> Prerequisites { get; set; } = new HashSet<LectureLabPrerequisite>();

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
