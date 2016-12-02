using DriveAPI.Core;
using DropBoxAPI;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WebDriveAPI
{
    class MainWindowViewModel : ViewModelBase
    {

        private DropBoxManagement DriveAPICurrentCase { get; set; }

        private IList<string> LastPathList = new List<string>();
        private bool isgobackpath = false;
        private IList<String> NextPathList = new List<string>();
        private bool isgoforwardpath = false;


        /// <summary>
        /// 当前文件列表
        /// </summary>
        public ICollectionView CurrentFileListView { get; set; }
        /// <summary>
        /// 文件列表处理——转换界面View显示
        /// </summary>
        private IList<WebFile> CurrentWebFileList
        {
            get
            {
                return CurrentFileListView.SourceCollection.Cast<WebFile>().ToList();
            }
            set
            {
                if (value != null)
                {
                    CurrentFileListView = new ListCollectionView(value.ToList());
                    CurrentFileListView.Refresh();
                    RaisePropertyChanged(() => CurrentFileListView);
                }
            }
        }

        private string currentFolderPath = string.Empty;
        /// <summary>
        /// 当前网络文件路径
        /// </summary>
        public String CurrentFolderPath
        {
            get { return this.currentFolderPath; }
            set
            {
                if (isgobackpath)
                {
                    if (LastPathList.Count > 0)
                    {
                        LastPathList.RemoveAt(LastPathList.Count - 1);
                    }
                    NextPathList.Add(currentFolderPath);
                }
                else if (isgoforwardpath)
                {
                    LastPathList.Add(currentFolderPath);
                    if (NextPathList.Count > 0)
                    {
                        NextPathList.RemoveAt(NextPathList.Count - 1);
                    }
                }
                else
                {
                    LastPathList.Add(currentFolderPath);
                    if (NextPathList.Count > 0)
                    {
                        NextPathList.Clear();
                    }
                }
                isgobackpath = false;
                isgoforwardpath = false;
                this.currentFolderPath = value;
                RaisePropertyChanged(() => CurrentFolderPath);
            }
        }

        private string operateMsg = "。。。";
        /// <summary>
        /// 当前操作信息提示
        /// </summary>
        public string OperateMsg
        {
            get { return operateMsg; }
            set
            {
                operateMsg = value;
                RaisePropertyChanged(() => OperateMsg);
            }
        }

        private string searchFilter = string.Empty;
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string SearchFilter
        {
            get { return searchFilter; }
            set
            {
                searchFilter = value;
                RaisePropertyChanged(() => SearchFilter);
            }
        }

        #region 命令
        /// <summary>
        /// 添加网盘链接
        /// </summary>
        public ICommand AddConnectionBoxCommand { get; set; }

        /// <summary>
        /// 上一个文件夹
        /// </summary>
        public ICommand LastFolderCommand { get; set; }
        /// <summary>
        /// 下一个文件夹
        /// </summary>
        public ICommand NextFolderCommand { get; set; }

        /// <summary>
        /// 返回根目录
        /// </summary>
        public ICommand GoRootFolderCommand { get; set; }

        /// <summary>
        /// 列表中相关文件夹打开操作
        /// </summary>
        public ICommand ListItemOpenCommand { get; set; }

        /// <summary>
        /// 上传文件
        /// </summary>
        public ICommand UploadFileCommand { get; set; }

        /// <summary>
        /// 下载文件
        /// </summary>
        public ICommand DownloadFileCommand { get; set; }

        /// <summary>
        /// 新建文件夹
        /// </summary>
        public ICommand NewFolderCommand { get; set; }

        /// <summary>
        /// 删除文件
        /// </summary>
        public ICommand DeleteFileCommand { get; set; }

        /// <summary>
        /// 搜索文件
        /// </summary>
        public ICommand SearchFileCommand { get; set; }

        #endregion

        /// <summary>
        /// 网页请求事件
        /// </summary>
        public event CancelEventHandler WebBrowserRequest = null;

        public MainWindowViewModel()
        {
            AddConnectionBoxCommand = new RelayCommand(AddConnectionBox);

            LastFolderCommand = new RelayCommand(LastFolder);
            NextFolderCommand = new RelayCommand(NextFolder);

            GoRootFolderCommand = new RelayCommand(GoRootFolder);
            ListItemOpenCommand = new RelayCommand(ListItemOpen);
            UploadFileCommand = new RelayCommand(UpLoadFile);
            DownloadFileCommand = new RelayCommand(DownLoadFile);
            NewFolderCommand = new RelayCommand(NewFolder);
            DeleteFileCommand = new RelayCommand(DeleteFile);

            SearchFileCommand = new RelayCommand(SearchFile);
        }

        #region 命令实现
        /// <summary>
        /// 添加新网盘链接
        /// </summary>
        private  void AddConnectionBox()
        {
            try
            {
                DriveAPICurrentCase = new DropBoxManagement();

                //if (WebBrowserRequest != null)
                //{
                //    DriveAPICurrentCase.CurrentAuthoRequestUri = await DriveAPICurrentCase.GetAuthRequestUrl();
                //    CancelEventArgs e = new CancelEventArgs();
                //    WebBrowserRequest(DriveAPICurrentCase, e);
                //    if (!e.Cancel)
                //    {
                //        await DriveAPICurrentCase.RefreshToken();
                //        OperateMsg = "连接成功";
                //        CurrentFolderPath = "/";
                //        var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
                //        CurrentWebFileList = list;
                //    }
                //}
            }
            catch
            {
            }
        }

        /// <summary>
        /// 上一个文件夹
        /// </summary>
        private  void LastFolder()
        {
            //if (LastPathList.Count > 0)
            //{
            //    isgobackpath = true;
            //    CurrentFolderPath = LastPathList.Last();

            //    var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
            //    CurrentWebFileList = list;
            //}
        }

        /// <summary>
        /// 下一个文件夹
        /// </summary>
        private  void NextFolder()
        {
            //if (NextPathList.Count > 0)
            //{
            //    isgoforwardpath = true;
            //    CurrentFolderPath = NextPathList.Last();

            //    var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
            //    CurrentWebFileList = list;
            //}
        }

        /// <summary>
        /// 返回根目录
        /// </summary>
        private  void GoRootFolder()
        {
            try
            {
                //var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
                //CurrentWebFileList = list;
                //CurrentFolderPath = "/";
                ////Button tmpc = new Button();
                ////tmpc.Content = "Dropbox";

                ////CheckBox sssssss = new CheckBox();
                ////Popup p = new Popup();
                ////Binding bingding = new Binding();
                ////bingding.ElementName = sssssss.Name;
                ////bingding.Path = new PropertyPath(sssssss.IsChecked);
                ////BindingOperations.SetBinding(p, Popup.IsOpenProperty, bingding);
                ////p.PlacementTarget = sssssss;
                ////ListBox sss = new ListBox();
                ////p.Child = sss;
                ////sss.ItemsSource = list;
                ////this.lb_path.Items.Add(tmpc);
                ////this.lb_path.Items.Add(sssssss);
                ////this.lb_path.Items.Add(p);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 列表目录打开下一层
        /// </summary>
        private  void ListItemOpen()
        {
            //if (CurrentFileListView != null && CurrentFileListView.CurrentItem != null)
            //{
            //    WebFile webfile = CurrentFileListView.CurrentItem as WebFile;
            //    if (webfile.IsDir)
            //    {
            //        var list = await DriveAPICurrentCase.GetFileList(webfile.FilePath);
            //        CurrentWebFileList = list;
            //        CurrentFolderPath = webfile.FilePath;
            //    }
            //}
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        private  void UpLoadFile()
        {
            //try
            //{
            //    OpenFileDialog dia = new OpenFileDialog();
            //    dia.Multiselect = false;
            //    if (dia.ShowDialog() == true)
            //    {
            //        var ss = await DriveAPICurrentCase.UploadFile(CurrentFolderPath, dia.FileName);
            //        var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
            //        CurrentWebFileList = list;
            //        OperateMsg = "上传成功";
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        private  void DownLoadFile()
        {
            //try
            //{
            //    if (CurrentFileListView != null && CurrentFileListView.CurrentItem != null)
            //    {
            //        WebFile webfile = CurrentFileListView.CurrentItem as WebFile;
            //        if (!webfile.IsDir)
            //        {
            //            FileInfo sss = new FileInfo(webfile.FileName);
            //            string filetype = sss.Extension;

            //            SaveFileDialog sfd = new SaveFileDialog();
            //            sfd.Filter = string.Format("*{0}|Choose File(*{0})|*.*|All Files(*.*)", filetype);
            //            sfd.FileName = webfile.FileName;
            //            if (sfd.ShowDialog() ?? false)
            //            {
            //                await DriveAPICurrentCase.DownLoadFile(webfile.FilePath, sfd.FileName);
            //                OperateMsg = "下载成功";
            //            }
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        /// <summary>
        /// 新建文件夹
        /// </summary>
        private  void NewFolder()
        {
            //try
            //{
            //    var query = from c in CurrentWebFileList where c.FileName.Contains("新建文件夹") && c.IsDir select c.FileName;
            //    string newfoldername = "新建文件夹";
            //    string folderformat = newfoldername + "{0}";
            //    int index = 1;
            //    if (query != null && query.Count() > 0)
            //    {
            //        while (true)
            //        {
            //            if (!query.Contains(newfoldername))
            //            {
            //                break;
            //            }
            //            newfoldername = string.Format(folderformat, index);
            //            index++;
            //        }
            //    }
            //    await DriveAPICurrentCase.CreateFolder(CurrentFolderPath, newfoldername);
            //    var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
            //    CurrentWebFileList = list;
            //    OperateMsg = "新建文件夹成功";
            //}
            //catch
            //{ }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        private  void DeleteFile()
        {
            //try
            //{
            //    if (CurrentFileListView != null && CurrentFileListView.CurrentItem != null)
            //    {

            //        WebFile webfile = CurrentFileListView.CurrentItem as WebFile;
            //        await DriveAPICurrentCase.DeleteFile(webfile.FilePath);
            //        var list = await DriveAPICurrentCase.GetFileList(CurrentFolderPath);
            //        CurrentWebFileList = list;
            //        OperateMsg = "删除完成";
            //    }
            //}
            //catch
            //{
            //}
        }

        private  void SearchFile()
        {
            //try
            //{
            //    CurrentWebFileList = await DriveAPICurrentCase.SearchFiles(SearchFilter);
            //    OperateMsg = "搜索完成";
            //}
            //catch
            //{
            //}
        }
        #endregion

    }
}
