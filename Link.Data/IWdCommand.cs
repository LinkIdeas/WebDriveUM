using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Data
{
    /// <summary>
    /// WebDriveCommand
    /// WebDrive Operate Interface——网盘操作接口
    /// </summary>
    interface IWdCommand
    {
        IWdConnection Connection { get; set; }

        
    }
}
