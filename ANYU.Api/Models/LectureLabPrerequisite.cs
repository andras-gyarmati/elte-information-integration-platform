using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("LectureLabPrerequisite")]
public class LectureLabPrerequisite
{
    [Key, Column(Order = 0)]
    public int LectureLabId { get; set; }

    [Key, Column(Order = 1)]
    public int PrerequisiteId { get; set; }

    [ForeignKey("LectureLabId")]
    public LectureLab LectureLab { get; set; }

    [ForeignKey("PrerequisiteId")]
    public LectureLab Prerequisite { get; set; }
}
