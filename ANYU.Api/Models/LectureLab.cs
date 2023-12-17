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
    public string Type { get; set; }

    [MaxLength(100)]
    public string Code { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int TeacherId { get; set; }

    [MaxLength(255)]
    public string Location { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [ForeignKey("CourseInstanceId")]
    public CourseInstance CourseInstance { get; set; }

    [ForeignKey("TeacherId")]
    public User Teacher { get; set; }

    public ICollection<LectureLabPrerequisite> Prerequisites { get; set; }

    public ICollection<UserLectureLabData> UserLectureLabData { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
