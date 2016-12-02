using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WebDriveAPI
{
    /// <summary>
    /// WindowLoginAndAccess.xaml 的交互逻辑
    /// 登陆与授权
    /// </summary>
    public partial class WindowLoginAndAccess : Window
    {
        public string Code { get; set; }

        public Uri LoginUrl { get; set; }

        public string DriveID { get; set; }


        public WindowLoginAndAccess()
        {
            InitializeComponent();

            this.wb_login.Navigating += wb_login_Navigating;
            this.wb_login.LoadCompleted += wb_login_LoadCompleted;
            this.Loaded += WindowLoginAndAccess_Loaded;
        }

        void WindowLoginAndAccess_Loaded(object sender, RoutedEventArgs e)
        {
            this.wb_login.Navigate(LoginUrl);
        }

        void wb_login_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e != null && e.Uri != null && e.Uri.ToString().StartsWith("http://www.canself.com"))
            {
                Code = HttpUtility.ParseQueryString(e.Uri.Query).Get("code");
                this.DialogResult = true;
                this.Close();
            }
        }

        void wb_login_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e != null && e.Uri != null)
            {
               // MessageBox.Show(e.Uri.ToString());
            }
            if (e != null && e.Uri != null && e.Uri.ToString().StartsWith("https://www.canself.com"))
            {
                (sender as WebBrowser).Navigate(e.Uri.ToString().Replace("https", "http"));
            }
        }
    }
}
