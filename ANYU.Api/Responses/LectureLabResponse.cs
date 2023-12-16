namespace ANYU.Api.Responses;

public class LectureLabResponse
{
    public int LectureLabId { get; set; }

    public int CourseInstanceId { get; set; }

    public string Type { get; set; }

    public string Code { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int TeacherId { get; set; }

    public string Location { get; set; }

    public string Description { get; set; }

    public string CourseInstance { get; set; }

    public string Teacher { get; set; }
}