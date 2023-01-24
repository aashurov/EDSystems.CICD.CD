using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Queries.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public GetUserListQueryHandler(UserManager<User> userManager, IMapper mapper) => (_userManager, _mapper) = (userManager, mapper);

    public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var customersQuery = await _userManager.Users.Include(r => r.UserRoles).ThenInclude(e => e.Role).AsNoTracking().ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        return new UserListVm { Customers = customersQuery };
    }
}