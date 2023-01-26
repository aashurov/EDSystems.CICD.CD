using AutoMapper;
using EDSystems.Application.Common.Exceptions;
using EDSystems.Domain.Entities;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Roles.Queries.GetRoleDetails;

public class GetRoleDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, RoleDetailsVm>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;

    public GetRoleDetailsQueryHandler(RoleManager<Role> roleManager, IMapper mapper) => (_roleManager, _mapper) = (roleManager, mapper);

    public async Task<RoleDetailsVm> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _roleManager.FindByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Branch), request.Id);
        }
        return _mapper.Map<RoleDetailsVm>(entity);
    }
}