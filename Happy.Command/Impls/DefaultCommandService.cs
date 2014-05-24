using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Practices.ServiceLocation;

using Happy.Utils.Reflection;

namespace Happy.Command.Impls
{
    internal sealed class DefaultCommandService : ICommandService
    {
        private Lazy<IServiceLocator> _locator = new Lazy<IServiceLocator>(() =>
                                                                ServiceLocator.Current);

        public DefaultCommandService() { }

        public DefaultCommandService(IServiceLocator locator)
        {
            Check.MustNotNull(locator, "locator");

            _locator = new Lazy<IServiceLocator>(() => locator);
        }

        public void Execute<TCommand>(TCommand command)
        {
            Check.MustNotNull(command, "command");

            var context = this.CreateCommandExecuteContext(command);

            context.Proceed();
        }



        private CommandExecuteContext CreateCommandExecuteContext<TCommand>(
                                                                TCommand command)
        {
            var handler = _locator.Value.GetInstance<ICommandHandler<TCommand>>();
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
