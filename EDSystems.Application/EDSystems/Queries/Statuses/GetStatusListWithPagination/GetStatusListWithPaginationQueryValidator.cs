using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Statuses.GetStatusListWithPagination;

public class GetStatusListWithPaginationQueryValidator : AbstractValidator<GetStatusListWithPaginationQuery>
{
    public GetStatusListWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}