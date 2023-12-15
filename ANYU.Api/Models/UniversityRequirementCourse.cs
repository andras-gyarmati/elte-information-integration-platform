using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANYU.Api.Models;

[Table("UniversityRequirementCourse")]
public class UniversityRequirementCourse
{
    [Key, Column(Order = 0)]
    public int RequirementId { get; set; }

    [Key, Column(Order = 1)]
    public int CourseId { get; set; }

    [ForeignKey("RequirementId")]
    public UniversityRequirement UniversityRequirement { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }
}
