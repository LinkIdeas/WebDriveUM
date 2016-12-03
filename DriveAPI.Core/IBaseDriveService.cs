using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveAPI.Core
{
    public interface IBaseDriveService
    {
        
        ///// <summary>
        ///// 权限申请地址
        ///// </summary>
        //Uri CurrentAuthoRequestUri { get; set; }

        ///// <summary>
        ///// Token的Code
        ///// </summary>
        //string Code { get; set; }

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

        UserInfo GetUserInfo();
        Task<UserInfo> GetUserInfoAsync();

        ///// <summary>
        ///// 刷新授权代码
        ///// </summary>
        ///// <returns></returns>
        //Task RefreshToken();

        ///// <summary>
        ///// 获取目录下文件列表
        ///// </summary>
        ///// <param name="path">文件路径</param>
        ///// <returns></returns>
        //Task<IList<WebFile>> GetFileList(string path);

        ///// <summary>
        ///// 上传文件
        ///// </summary>
        ///// <param name="fileStream"></param>
        ///// <param name="filepath"></param>
        ///// <param name="filename"></param>
        ///// <returns></returns>
        //Task<WebFile> UploadFile(string webpath, string filename);

        ///// <summary>
        ///// 下载文件
        ///// </summary>
        ///// <param name="webfilepath"></param>
        ///// <param name="localfilename"></param>
        ///// <returns></returns>
        //Task<WebFile> DownLoadFile(string webfilepath, string localfilename);

        ///// <summary>
        ///// 新建文件夹
        ///// </summary>
        //Task CreateFolder(string path, string foldername);

        ///// <summary>
        ///// 删除文件
        ///// </summary>
        ///// <param name="webfilepath"></param>
        ///// <returns></returns>
        //Task<WebFile> DeleteFile(string webfilepath);

        ///// <summary>
        ///// 搜索文件
        ///// </summary>
        ///// <param name="filename"></param>
        ///// <returns></returns>
        //Task<IList<WebFile>> SearchFiles(string filename);

    }

}
