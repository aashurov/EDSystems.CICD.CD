using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.Interfaces;
using EDSystems.Persistence;
using EDSystems.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSystems.Tests.EDSystems.Commands
{
    public class QueryTestFixture : IDisposable
    {
        public EDSystemsDbContext Context;
        public IMapper Mapper;
        public QueryTestFixture()
        {
            Context = BranchContextFactory.Create();

            var configurationProfile = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IEDSystemsDbContext).Assembly));
            });
            Mapper = configurationProfile.CreateMapper();
        }

        public void Dispose()
        {
            BranchContextFactory.Destroy(Context);
        }


    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
