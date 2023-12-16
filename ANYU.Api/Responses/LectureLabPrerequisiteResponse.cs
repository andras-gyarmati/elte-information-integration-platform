namespace ANYU.Api.Responses;

public class LectureLabPrerequisiteResponse
{
    public int LectureLabPrerequisiteId { get; set; }

    public int LectureLabId { get; set; }

    public int CourseId { get; set; }

    public string Course { get; set; }

    public string LectureLab { get; set; }
}