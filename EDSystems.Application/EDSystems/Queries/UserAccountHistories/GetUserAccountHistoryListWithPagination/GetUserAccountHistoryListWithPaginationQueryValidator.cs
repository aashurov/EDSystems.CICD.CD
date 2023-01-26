using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.UserAccountHistories.GetUserAccountHistoryListWithPagination;

public class GetUserAccountHistoryListWithPaginationQueryValidator : AbstractValidator<GetUserAccountHistoryListWithPaginationQuery>
{
    public GetUserAccountHistoryListWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}