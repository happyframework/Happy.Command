using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Happy.Command.Test.Stub.Simple;

namespace Happy.Command.Test
{
    [TestFixture]
    public class CommandServiceTest
    {
        [Test]
        public void Execute_Simple_Test()
        {
            var testCommand = new TestCommand();

            CommandService.Current.Execute(testCommand);

            Assert.IsTrue(testCommand.Output.Contains(typeof(TestCommandHandler).Name));
            Assert.IsTrue(testCommand.Output.Contains(typeof(TestCommandInterceptor1Attibute).Name));
            Assert.IsTrue(testCommand.Output.Contains(typeof(TestCommandInterceptor2Attibute).Name));
            Assert.IsTrue(testCommand.Output.StartsWith("Before:" + typeof(TestCommandInterceptor1Attibute).Name));
            Assert.IsTrue(testCommand.Output.EndsWith("After:" + typeof(TestCommandInterceptor1Attibute).Name));
        }
    }
}
