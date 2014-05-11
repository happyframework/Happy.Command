using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Happy.Utils.Reflection;
using Happy.Factory;

namespace Happy.Command.Internal
{
    internal sealed class DefaultCommandService : ICommandService
    {
        private IFactory _factory = new DefaultFactory();

        public void Execute<TCommand>(TCommand command)
        {
            Check.MustNotNull(command, "command");

            var context = this.CreateCommandExecuteContext(command);

            context.Next();
        }

        public void SetFactory(Factory.IFactory factory)
        {
            Check.MustNotNull(factory, "factory");

            _factory = factory;
        }

        private CommandExecuteContext CreateCommandExecuteContext<TCommand>(
                                                                TCommand command)
        {
            var handler = _factory
                                    .CreateInstance<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandException(
                                Resource.Messages.Error_CommandHandlerNotExist);
            }

            var interceptors = handler.GetType()
                                    .GetAttributes<CommandInterceptorAttribute>();

            return new CommandExecuteContext(command, interceptors, () =>
            {
                handler.Handle(command);
            });
        }
    }
}
