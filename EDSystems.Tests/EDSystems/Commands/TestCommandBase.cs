using EDSystems.Persistence;
using EDSystems.Tests.Common;

namespace EDSystems.Tests.EDSystems.Commands
{
    public class TestCommandBase : IDisposable
    {
        protected readonly EDSystemsDbContext Context;

        public TestCommandBase()
        {
            Context = BranchContextFactory.Create();
        }

        public void Dispose()
        {
            BranchContextFactory.Destroy(Context);
        }
    }
}