using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Command
{
    /// <summary>
    /// 命令异常。
    /// </summary>
    public sealed class CommandException : ApplicationException
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        public CommandException(string message)
            : base(message)
        {

        }
    }
}
