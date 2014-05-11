using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Command;

namespace Happy.Command.Test.Stub.Simple
{
    public sealed class TestCommandInterceptor2Attibute :
                                                    CommandInterceptorAttribute
    {
        public TestCommandInterceptor2Attibute(int order)
            : base(order)
        {
        }

        public override void Intercept(ICommandExecuteContext context)
        {
            (context.Command as TestCommand).Output += 
                                    ("Before:TestCommandInterceptor2Attibute");
            context.Next();
            (context.Command as TestCommand).Output += 
                                    ("After:TestCommandInterceptor2Attibute");
        }
    }
}
