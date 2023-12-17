namespace ANYU.Api.Responses;

public class CourseResponse
{
    public int CourseId { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Category { get; set; }

    public int Credit { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string InstanceDescription { get; set; }

    public List<LectureLabResponse> Lectures { get; set; }
    public List<LectureLabResponse> Labs { get; set; }
}
