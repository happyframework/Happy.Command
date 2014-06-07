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
        public void Execute<TCommand>(TCommand command)
        {
            Check.MustNotNull(command, "command");

            var context = this.CreateCommandExecuteContext(command);

            context.Proceed();
        }

        private CommandExecuteContext CreateCommandExecuteContext<TCommand>(
                                                                TCommand command)
        {
            var handler = ServiceLocator.Current.GetInstance<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandException(
                                Resource.Messages.Error_CommandHandlerNotExist);
            }

            var interceptors = GetInterceptors<TCommand>(command, handler);

            return new CommandExecuteContext(command, interceptors, () =>
            {
                handler.Handle(command);
            });
        }

        private static IEnumerable<CommandInterceptorAttribute> GetInterceptors<TCommand>
                                    (TCommand command, ICommandHandler<TCommand> handler)
        {
            var commandInterceptors = command.GetType()
                                    .GetAttributes<CommandInterceptorAttribute>();

            var handlerInterceptors = handler.GetType()
                                    .GetAttributes<CommandInterceptorAttribute>();

            return commandInterceptors.Concat(handlerInterceptors);
        }
    }
}
