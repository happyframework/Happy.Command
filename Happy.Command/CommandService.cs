using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Command.Impls;

namespace Happy.Command
{
    /// <summary>
    /// 获取或访问<see cref="ICommandService"/>实例的唯一入口。
    /// </summary>
    public static class CommandService
    {
        private static readonly DefaultCommandService _DefaultCommandService
                                                            = new DefaultCommandService();

        /// <summary>
        /// 当前应用程序正在使用的命令服务。
        /// </summary>
        public static ICommandService Current
        {
            get { return _DefaultCommandService; }
        }
    }
}
