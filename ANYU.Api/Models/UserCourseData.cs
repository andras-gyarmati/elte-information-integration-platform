using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("UserCourseData")]
public class UserCourseData
{
    public int UserId { get; set; }

    public int LectureLabId { get; set; }

    [MaxLength(100)]
    public string Grade { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("LectureLabId")]
    public LectureLab LectureLab { get; set; }

    public List<UserCompletedRequirement> CompletedRequirements { get; set; }

    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    [MaxLength(255)]
    public string ModifiedBy { get; set; }
}
