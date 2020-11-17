using System;
using Bookeasy.Persistence;

namespace Bookeasy.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly NorthwindDbContext _context;

        public CommandTestBase()
        {
            _context = NorthwindContextFactory.Create();
        }

        public void Dispose()
        {
            NorthwindContextFactory.Destroy(_context);
        }
    }
}