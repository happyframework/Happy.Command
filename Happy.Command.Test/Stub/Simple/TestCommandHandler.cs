using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Command;

namespace Happy.Command.Test.Stub.Simple
{
    [TestCommandInterceptor1Attibute(1)]
    [TestCommandInterceptor2Attibute(2)]
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public void Handle(TestCommand command)
        {
            command.Output += ("TestCommandHandler");
        }
    }
}
