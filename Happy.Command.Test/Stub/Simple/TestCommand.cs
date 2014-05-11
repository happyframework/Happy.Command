using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Command;

namespace Happy.Command.Test.Stub.Simple
{
    public sealed class TestCommand
    {
        public TestCommand()
        {
            this.Output = "";
        }

        public string Output { get; set; }
    }
}
