using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("UserCourseData")]
public class UserCourseData
{
    public int UserId { get; set; }

    public int CourseInstanceId { get; set; }

    [MaxLength(100)]
    public string Grade { get; set; } = null!;

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    [ForeignKey("CourseInstanceId")]
    public CourseInstance CourseInstance { get; set; } = null!;

    public List<UserCompletedRequirement> CompletedRequirements { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
