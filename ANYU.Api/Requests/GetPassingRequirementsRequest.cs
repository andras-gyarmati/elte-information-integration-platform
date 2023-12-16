﻿using ANYU.Api.Abstraction;
using ANYU.Api.Responses;
using MediatR;

namespace ANYU.Api.Requests;

public class GetPassingRequirementsRequest : IRequest<PagedListResult<PassingRequirementResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}