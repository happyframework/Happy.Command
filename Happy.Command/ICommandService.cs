using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Factory;

namespace Happy.Command
{
    /// <summary>
    /// 命令服务接口，负责执行命令。
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// 执行<paramref name="command"/>。
        /// </summary>
        /// <exception cref="CommandException"></exception>
        void Execute<TCommand>(TCommand command);

        /// <summary>
        /// 设置<paramref name="factory"/>。
        /// </summary>
        void SetFactory(IFactory factory);
    }
}
