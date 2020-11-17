using System;
using Bookeasy.Common;

namespace Bookeasy.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
