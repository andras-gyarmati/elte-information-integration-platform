using ANYU.Api.Abstraction;
using ANYU.Api.Responses;
using MediatR;

namespace ANYU.Api.Requests;

public class GetCourseRequest : IRequest<Result<CourseResponse>>
{
    public string Code { get; set; }
}