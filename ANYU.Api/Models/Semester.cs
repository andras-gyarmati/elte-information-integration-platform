using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("Semester")]
public class Semester
{
    [Key]
    public int SemesterId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int StudyPeriodWeeks { get; set; }

    public int ExamPeriodWeeks { get; set; }

    public ICollection<CourseInstance> CourseInstances { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
