﻿using DeveloperKeyInfo;
using DriveAPI.Core;
using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DropBoxManager
{
    [Export("DropBox", typeof(IBaseDriveService))]
    public class DropBoxManagement : IBaseDriveService
    {
        private string AccessToken;

        /// <summary>
        /// 权限申请地址
        /// </summary>
        public Uri CurrentAuthoRequestUri { get; set; }

        public string Code { get; set; }


        //public Options Option { get; private set; }

        //public Client TmpClient { get; private set; }



        public DropBoxManagement()
        {
            //Option = new Options();
            //Option.ClientId = Key.Dropbox_AppKey;
            //Option.ClientSecret = Key.Dropbox_AppSecret;
            //Option.RedirectUri = "https://www.canself.com";

            //TmpClient = new Client(Option);
        }

        public Task<Uri> GetAuthPageAddressAsync()
        {
            throw new NotImplementedException();
        }

        public Uri GetAuthPageAddress()
        {
            return DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, LocalKey.Dropbox_AppKey, "https://www.canself.com", state: Guid.NewGuid().ToString("N"));
        }

        public void SetAccessToken(Uri result)
        {
            OAuth2Response result1 = DropboxOAuth2Helper.ParseTokenFragment(result);
            this.AccessToken = result1.AccessToken;
        }

        public UserInfo GetUserInfo()
        {
            throw new NotImplementedException();

        }

        HttpClient client = new HttpClient();

        public async Task<UserInfo> GetUserInfoAsync()
        {
            UserInfo user = new UserInfo();
            var config = new DropboxClientConfig() { HttpClient = client };
            using (var dbx = new DropboxClient(AccessToken, config))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                user.Email = full.Email;
                user.Name = full.Name.DisplayName;
            }
            return user;
        }

        //public async Task RefreshToken()
        //{
        //    var client = new Client(Option);
        //    var token = await client.Core.OAuth2.TokenAsync(Code);
        //}

        ///// <summary>
        ///// 刷新授权代码
        ///// </summary>
        ///// <param name="code"></param>
        //public async void RefreshToken(string code)
        //{
        //    var client = new Client(Option);
        //    var token = await client.Core.OAuth2.TokenAsync(code);
        //}

        ///// <summary>
        ///// 获取权限uri
        ///// </summary>
        ///// <returns></returns>
        //public async Task<Uri> GetAuthRequestUrl()
        //{
        //    var client = new Client(Option);
        //    return await client.Core.OAuth2.AuthorizeAsync("code");
        //}

        ///// <summary>
        ///// 获取账户信息
        ///// </summary>
        ///// <returns></returns>
        //public async Task<string> GetUserInfo()
        //{
        //    Client client = new Client(Option);
        //    var accountInfo = await client.Core.Accounts.AccountInfoAsync();
        //    return accountInfo.uid.ToString();
        //    //MessageBox.Show(string.Format("Uid:{0}\r\nDisplay_name:{1}\r\n", accountInfo.uid, accountInfo.display_name));
        //}

        //public async Task<WebFile> GetRootFolder()
        //{
        //    WebFile webfile = new WebFile();
        //    var rootFolder = await TmpClient.Core.Metadata.MetadataAsync("/", list: false);
        //    webfile.IsDir = rootFolder.is_dir;
        //    webfile.FilePath = rootFolder.path;
        //    webfile.FileName = rootFolder.Name;
        //    return webfile;
        //}

        ///// <summary>
        ///// 获取目录下文件列表
        ///// </summary>
        ///// <param name="path">文件路径</param>
        ///// <returns></returns>
        //public async Task<IList<WebFile>> GetFileList(string path)
        //{
        //    Client client = new Client(Option);
        //    var rootfolder = await client.Core.Metadata.MetadataAsync(Path.Combine(path), list: true);
        //    IList<WebFile> tmp = new List<WebFile>();
        //    foreach (var item in rootfolder.contents)
        //    {
        //        WebFile webfile = new WebFile();
        //        webfile.IsDir = item.is_dir;
        //        webfile.FileName = item.Name;
        //        webfile.FilePath = item.path;
        //        tmp.Add(webfile);
        //    }
        //    return tmp;
        //}

        ///// <summary>
        ///// 上传文件
        ///// </summary>
        ///// <param name="fileStream"></param>
        ///// <param name="filepath"></param>
        ///// <param name="filename"></param>
        ///// <returns></returns>
        //public async Task<WebFile> UploadFile(string webpath, string filename)
        //{
        //    Client client = new Client(Option);
        //    FileInfo file = new FileInfo(filename);
        //    WebFile webfile = new WebFile();
        //    FileStream fileStream = System.IO.File.OpenRead(filename);
        //    try
        //    {
        //        var ss = await client.Core.Metadata.FilesPutAsync(fileStream, Path.Combine(webpath, file.Name).Replace('\\', '/'), CultureInfo.CurrentCulture.EnglishName);

        //        webfile.IsDir = ss.is_dir;
        //        webfile.FilePath = ss.path;
        //        webfile.FileName = ss.Name;
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        fileStream.Close();
        //    }
        //    return webfile;
        //}

        ///// <summary>
        ///// 下载文件
        ///// </summary>
        ///// <param name="webfilepath"></param>
        ///// <param name="localfilename"></param>
        ///// <returns></returns>
        //public async Task<WebFile> DownLoadFile(string webfilepath, string localfilename)
        //{
        //    Client client = new Client(Option);
        //    var filestream = System.IO.File.OpenWrite(localfilename);
        //    var ss = await client.Core.Metadata.FilesAsync(webfilepath, filestream);//下载完成好像是返回null
        //    filestream.Close();

        //    WebFile webfile = new WebFile();
        //    if (ss != null)
        //    {
        //        webfile.IsDir = ss.is_dir;
        //        webfile.FileName = ss.Name;
        //        webfile.FilePath = ss.path;
        //    }
        //    return webfile;
        //}

        ///// <summary>
        ///// 新建文件夹
        ///// </summary>
        //public async Task CreateFolder(string path, string foldername)
        //{
        //    Client client = new Client(Option);
        //    var newfolder = await client.Core.FileOperations.CreateFolderAsync(Path.Combine(path, foldername).Replace('\\', '/'));
        //}

        ///// <summary>
        ///// 删除文件
        ///// </summary>
        ///// <param name="webfilepath"></param>
        ///// <returns></returns>
        //public async Task<WebFile> DeleteFile(string webfilepath)
        //{
        //    var ss = await TmpClient.Core.FileOperations.DeleteAsync(webfilepath);

        //    WebFile webfile = new WebFile();
        //    if (ss != null)
        //    {
        //        webfile.IsDir = ss.is_dir;
        //        webfile.FileName = ss.Name;
        //        webfile.FilePath = ss.path;
        //    }
        //    return webfile;
        //}

        ///// <summary>
        ///// 搜索文件
        ///// </summary>
        ///// <param name="filename"></param>
        ///// <returns></returns>
        //public async Task<IList<WebFile>> SearchFiles(string filename)
        //{
        //    IList<WebFile> tmp = new List<WebFile>();
        //    var searchResults = await TmpClient.Core.Metadata.SearchAsync("/", filename);
        //    foreach (var item in searchResults)
        //    {
        //        WebFile webfile = new WebFile();
        //        webfile.IsDir = item.is_dir;
        //        webfile.FileName = item.Name;
        //        webfile.FilePath = item.path;
        //        tmp.Add(webfile);
        //    }
        //    return tmp;
        //}

    }
}
