using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Roles.Queries.GetRoleList;

public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, RoleListVm>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;

    public GetRoleListQueryHandler(RoleManager<Role> roleManager, IMapper mapper) => (_roleManager, _mapper) = (roleManager, mapper);

    public async Task<RoleListVm> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        var customersQuery = await _roleManager.Roles
            .ProjectTo<RoleListLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new RoleListVm { Roles = customersQuery };
    }
}