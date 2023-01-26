using FluentValidation;

namespace EDSystems.Application.Roles.Queries.GetRoleListWithPagination;

public class GetRolesListWithPaginationQueryValidator : AbstractValidator<GetRoleListWithPaginationQuery>
{
    public GetRolesListWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}