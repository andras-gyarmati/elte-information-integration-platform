namespace ANYU.Api.Responses;

public class UniversityRequirementResponse
{
    public int UniversityRequirementId { get; set; }

    public int UniversityId { get; set; }

    public int CourseId { get; set; }

    public string University { get; set; }

    public string Course { get; set; }
}