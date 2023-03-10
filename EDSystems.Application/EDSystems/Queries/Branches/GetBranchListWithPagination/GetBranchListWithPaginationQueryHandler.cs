using AutoMapper;
using AutoMapper.QueryableExtensions;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Common.Models;
using EDSystems.Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSystems.Application.EDSystems.Queries.Branches.GetBranchListWithPagination;

public class GetBranchListWithPaginationQueryHandler : IRequestHandler<GetBranchListWithPaginationQuery, PaginatedList<BranchLookupDtoWithPagination>>
{
    private readonly IEDSystemsDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;
    private static object _lock = new object();

    public GetBranchListWithPaginationQueryHandler(IEDSystemsDbContext dbContext, IMapper mapper, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedList<BranchLookupDtoWithPagination>> Handle(GetBranchListWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var casheData = _cacheService.GetData<PaginatedList<BranchLookupDtoWithPagination>>("BranchLookupDtoWithPagination");

        if (casheData != null)
            return casheData;

        casheData = await _dbContext.Branch.OrderBy(x => x.Id)
           .ProjectTo<BranchLookupDtoWithPagination>(_mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize);
        lock (_lock)
        {
            var expiryTime = DateTimeOffset.Now.AddMinutes(4);
            //_cacheService.SetData($"BranchLookupDtoWithPagination/{request.PageNumber}/{request.PageSize}", casheData, expiryTime);
            _cacheService.SetData($"BranchLookupDtoWithPagination/{request.PageNumber}/{request.PageSize}", casheData, expiryTime);
        }
        return casheData;

        //return await _dbContext.Branch.OrderBy(x => x.Id)
        //    .ProjectTo<BranchLookupDtoWithPagination>(_mapper.ConfigurationProvider)
        //    .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}