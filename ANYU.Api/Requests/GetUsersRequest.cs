using ANYU.Api.Abstraction;
using ANYU.Api.Responses;
using MediatR;

namespace ANYU.Api.Requests;

// todo: move to separate files
// users
public class GetUsersRequest : IRequest<PagedListResult<UserResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// courses
public class GetCoursesRequest : IRequest<PagedListResult<CourseResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

public class GetCourseRequest : IRequest<Result<CourseResponse>>
{
    public string Code { get; set; }
}

// course instances
public class GetCourseInstancesRequest : IRequest<PagedListResult<CourseInstanceResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// lecture labs
public class GetLectureLabsRequest : IRequest<PagedListResult<LectureLabResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// lecture lab prerequisites
public class GetLectureLabPrerequisitesRequest : IRequest<PagedListResult<LectureLabPrerequisiteResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// passing requirements
public class GetPassingRequirementsRequest : IRequest<PagedListResult<PassingRequirementResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// semesters
public class GetSemestersRequest : IRequest<PagedListResult<SemesterResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// universities
public class GetUniversitiesRequest : IRequest<PagedListResult<UniversityResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}

// university requirements
public class GetUniversityRequirementsRequest : IRequest<PagedListResult<UniversityRequirementResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}
