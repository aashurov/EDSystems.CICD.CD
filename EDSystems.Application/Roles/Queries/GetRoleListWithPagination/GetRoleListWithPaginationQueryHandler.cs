using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Roles.Queries.GetRoleListWithPagination;

public class GetRoleListWithPaginationQueryHandler : IRequestHandler<GetRoleListWithPaginationQuery, PaginatedList<RoleListLookupDtoWithPagination>>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;

    public GetRoleListWithPaginationQueryHandler(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RoleListLookupDtoWithPagination>> Handle(GetRoleListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _roleManager.Roles
            .ProjectTo<RoleListLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}