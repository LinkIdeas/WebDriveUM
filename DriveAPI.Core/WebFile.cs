using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveAPI.Core
{
    /// <summary>
    /// 网络文件类——用于记录网盘中文件的属性
    /// </summary>
    public class WebFile
    {
        /// <summary>
        /// 是否是目录
        /// </summary>
        public bool IsDir { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        //文件路径
        public string FilePath { get; set; }
    }
}
