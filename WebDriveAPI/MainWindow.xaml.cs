using DropBoxAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mshtml;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Microsoft.Win32;
using DriveAPI.Core;
using System.Windows.Controls.Primitives;

namespace WebDriveAPI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowViewModel ViewModel
        {
            get { return this.DataContext as MainWindowViewModel; }
            set { this.DataContext = value; }
        }


        string currentpath = "/";
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            ViewModel.WebBrowserRequest += ViewModel_WebBrowserRequest;

            this.lv_filelist.PreviewMouseDoubleClick += lv_filelist_PreviewMouseDoubleClick;
        }

        void ViewModel_WebBrowserRequest(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender != null)
            {
                IBaseDriveService tempservice = sender as IBaseDriveService;

                var authRequestUrl = tempservice.CurrentAuthoRequestUri;

                WindowLoginAndAccess win = new WindowLoginAndAccess();
                win.LoginUrl = authRequestUrl;
                win.DriveID = "dropbox";
                if (win.ShowDialog() ?? false)
                {
                    tempservice.Code = win.Code;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 列表内容点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_filelist_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.lv_filelist.ItemsSource != null && this.lv_filelist.SelectedIndex >= 0)
            {
                //WebFile webfile = this.lv_filelist.SelectedItem as WebFile;
                //if (webfile.IsDir)
                //{
                //    var list = await tmp.GetFileList(webfile.FilePath);
                //    this.lv_filelist.ItemsSource = list;
                //    this.currentpath = webfile.FilePath;
                //}
                ViewModel.ListItemOpenCommand.Execute(null);
            }
        }

        DropBoxManagement tmp;

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //     string user = await tmp.GetUserInfo();
            //  MessageBox.Show(user);
            this.pop.IsOpen = true;
        }

    }
}
