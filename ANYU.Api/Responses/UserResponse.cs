namespace ANYU.Api.Responses;

// todo: move to separate files
// users
public class UserResponse
{
    public string Name { get; set; }

    public string Email { get; set; }
}

// courses
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
}

// course instances
public class CourseInstanceResponse
{
    public int CourseInstanceId { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public string Description { get; set; }

    public string Course { get; set; }

    public string Semester { get; set; }
}

// lecture labs
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

// lecture lab prerequisites
public class LectureLabPrerequisiteResponse
{
    public int LectureLabPrerequisiteId { get; set; }

    public int LectureLabId { get; set; }

    public int CourseId { get; set; }

    public string Course { get; set; }

    public string LectureLab { get; set; }
}

// passing requirements
public class PassingRequirementResponse
{
    public int PassingRequirementId { get; set; }

    public int CourseId { get; set; }

    public string Course { get; set; }

    public int PassingScore { get; set; }
}

// semesters
public class SemesterResponse
{
    public int SemesterId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

// universities
public class UniversityResponse
{
    public int UniversityId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

// university requirements
public class UniversityRequirementResponse
{
    public int UniversityRequirementId { get; set; }

    public int UniversityId { get; set; }

    public int CourseId { get; set; }

    public string University { get; set; }

    public string Course { get; set; }
}
