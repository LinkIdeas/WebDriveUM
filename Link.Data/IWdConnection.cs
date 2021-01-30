using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Data
{
    /// <summary>
    /// WebDriveConnection
    /// WebDrive Connect Interface——网盘连接接口
    /// </summary>
    interface IWdConnection
    {
        string AccessToken { get; set; }

        /// <summary>
        /// 【异步】获取授权页面地址
        /// </summary>
        /// <returns></returns>
        Task<Uri> GetAuthPageAddressAsync();
        /// <summary>
        /// 获取授权页面地址
        /// </summary>
        /// <returns></returns>
        Uri GetAuthPageAddress();

        void SetAccessToken(Uri result);

    }
}
