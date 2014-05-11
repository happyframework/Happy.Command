﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Command
{
    /// <summary>
    /// 命令执行上下文接口，代表了一次命令的执行过程。
    /// </summary>
    public interface ICommandExecuteContext
    {
        /// <summary>
        /// 正在执行的命令。
        /// </summary>
        object Command { get; }

        /// <summary>
        /// 执行下一个<see cref="CommandInterceptorAttribute"/>，如果已经是最后一个，就会
        /// 执行<see cref="ICommandHandler{TCommand}"/>。
        /// </summary>
        void Next();
    }
}
