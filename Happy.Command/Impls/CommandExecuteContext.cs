using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Command.Impls
{
    internal sealed class CommandExecuteContext : ICommandExecuteContext
    {
        private readonly List<CommandInterceptorAttribute> _interceptors;
        private readonly Action _delagateWapper;
        private int _currentInterceptorIndex = -1;

        internal CommandExecuteContext(object command,
                            IEnumerable<CommandInterceptorAttribute> interceptors,
                            Action delagateWapper)
        {
            Check.MustNotNull("command", "command");
            Check.MustNotNull("interceptors", "interceptors");
            Check.MustNotNull("delagateWapper", "delagateWapper");

            this.Command = command;
            _interceptors = interceptors.OrderBy(x => x.Order).ToList();
            _delagateWapper = delagateWapper;
        }

        public object Command { get; private set; }

        public void Proceed()
        {
            _currentInterceptorIndex++;
            if (_currentInterceptorIndex < _interceptors.Count)
            {
                _interceptors[_currentInterceptorIndex].Intercept(this);
            }
            else
            {
                _delagateWapper();
            }
        }
    }
}
