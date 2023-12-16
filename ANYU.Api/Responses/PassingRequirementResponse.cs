namespace ANYU.Api.Responses;

public class PassingRequirementResponse
{
    public int PassingRequirementId { get; set; }

    public int CourseId { get; set; }

    public string Course { get; set; }

    public int PassingScore { get; set; }
}