using AutoMapper;
using EDSystems.Application.EDSystems.Queries.Branches.GetBranchList;
using EDSystems.Persistence;
using EDSystems.Tests.EDSystems.Commands;
using MediatR;
using Shouldly;

namespace EDSystems.Tests.EDSystems.Queries.Branches;

[Collection("QueryCollection")]
public class GetBranchListQueryHandlerTest
{
    private readonly EDSystemsDbContext Context;
    private readonly IMapper Mapper;

    public GetBranchListQueryHandlerTest(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetBranchListQueryHandlerTest_Success()
    {
        //Arrange
        var handler = new GetBranchListQueryHandler(Context, Mapper);

        //Act
        var result = await handler.Handle(
            new GetBranchListQuery
            {
                //UserId = NotesContextFactory.UserBid,
            }, CancellationToken.None);
       
        var vm = await Mediator.Send(result);

        //Assert
        result.ShouldBeOfType<BranchListVm>();
        result.Branches.Count.ShouldBe(3);
    }
}