using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.Users.Queries.GetUserListWithPagination;

public class GetUserListWithPaginationQueryHandler : IRequestHandler<GetUserListWithPaginationQuery, PaginatedList<UserLookupDtoWithPagination>>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public GetUserListWithPaginationQueryHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserLookupDtoWithPagination>> Handle(GetUserListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users
            .Include(r => r.UserRoles).ThenInclude(e => e.Role).AsNoTracking()
            .ProjectTo<UserLookupDtoWithPagination>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}