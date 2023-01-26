using FluentValidation;

namespace EDSystems.Application.EDSystems.Queries.Accounts.GetAccountListWithPagination;

public class GetAccountListWithPaginationQueryValidator : AbstractValidator<GetAccountListWithPaginationQuery>
{
    public GetAccountListWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}