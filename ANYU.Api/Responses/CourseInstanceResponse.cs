namespace ANYU.Api.Responses;

public class CourseInstanceResponse
{
    public int CourseInstanceId { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public string Description { get; set; }

    public string Course { get; set; }

    public string Semester { get; set; }
}